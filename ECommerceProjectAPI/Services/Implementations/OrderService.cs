using AutoMapper;
using ECommerceProjectAPI.Data;
using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;
using ECommerceProjectAPI.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, AppDbContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse<bool>> CancelOrderAsync(int id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(id);
                if (order == null)
                {
                    return ApiResponse<bool>.FailureResponse("Order not found.");
                }
                if (order.OrderStatus == Models.OrderStatus.Cancelled)
                {
                    return ApiResponse<bool>.FailureResponse("Order is already cancelled.");
                }
                if(order.OrderStatus == Models.OrderStatus.Shipped || order.OrderStatus == Models.OrderStatus.Delivered)
                {
                    return ApiResponse<bool>.FailureResponse("Cannot cancel an order that has been shipped or delivered.");
                }
                order.OrderStatus = Models.OrderStatus.Cancelled;
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Order cancelled successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"An error occurred while cancelling the order. { ex.Message }");
            }
        }

        public async Task<ApiResponse<OrderResponseDto>> CreateOrderAsync(int customerId, CreateOrderRequestDto orderDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var cart = await _context.Carts
                    .Include(c => c.Items)
                    .ThenInclude(ci => ci.Product)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);
                if (cart == null || !cart.Items.Any())
                    return ApiResponse<OrderResponseDto>.FailureResponse("Cart is empty or does not exist.");

                foreach (var item in cart.Items)
                {
                    if (item.Product.StockQuantity < item.Quantity)
                    {
                        return ApiResponse<OrderResponseDto>.FailureResponse($"Insufficient stock for product {item.Product.ProductName}.");
                    }
                }
                var order = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    OrderStatus = OrderStatus.Pending,
                    CustomerId = customerId,
                    AddressId = orderDto.AddressId,
                    Items = cart.Items.Select(ci => new OrderItem
                    {
                        ProductId = ci.ProductId,
                        Quantity = ci.Quantity,
                        UnitPrice = ci.Product.ProductPrice
                    }).ToList()
                };
                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();

                foreach(var cartItem in cart.Items)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.Product.ProductPrice
                    };
                    await _unitOfWork.OrderItems.AddAsync(orderItem);
                    cartItem.Product.StockQuantity -= cartItem.Quantity;
                    _unitOfWork.Products.Update(cartItem.Product);
                }
                
                _unitOfWork.CartItems.RemoveRange(cart.Items);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return await GetOrderByIdAsync(order.OrderId);

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResponse<OrderResponseDto>.FailureResponse($"An error occurred while creating the order. { ex.Message }");
            }
        }

        public async Task<ApiResponse<bool>> DeleteOrderAsync(int id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(id);
                if (order == null)
                {
                    return ApiResponse<bool>.FailureResponse("Order not found.");
                }
                _unitOfWork.Orders.Remove(order);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Order deleted successfully.");
            }
            catch(Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"An error occurred while deleting the order. { ex.Message }");
            }
        }

        public async Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetAllOrdersAsync()
        {
            try
            {
                var orders = await _unitOfWork.Orders.GetAllAsync();
                if(orders == null || !orders.Any())
                {
                    return ApiResponse<IEnumerable<OrderResponseDto>>.FailureResponse("No orders found.");
                }
                var orderDtos = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
                return ApiResponse<IEnumerable<OrderResponseDto>>.SuccessResponse(orderDtos, "Orders retrieved successfully.");
            }
            catch(Exception ex)
            {
                return ApiResponse<IEnumerable<OrderResponseDto>>.FailureResponse($"An error occurred while retrieving orders. { ex.Message }");
            }
        }

        public async Task<ApiResponse<OrderResponseDto>> GetOrderByIdAsync(int id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(id);
                if (order == null)
                {
                    return ApiResponse<OrderResponseDto>.FailureResponse("Order not found.");
                }
                var orderDto = _mapper.Map<OrderResponseDto>(order);
                return ApiResponse<OrderResponseDto>.SuccessResponse(orderDto, "Order retrieved successfully.");
            }
            catch(Exception ex)
            {
                return ApiResponse<OrderResponseDto>.FailureResponse($"An error occurred while retrieving the order. { ex.Message }");
            }
        }

        public async Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetOrdersByCustomerIdAsync(int customerId)
        {
            try
            {
                var order = await _context.Orders
                    .Where(o => o.CustomerId == customerId)
                    .ToListAsync();
                if (order == null || !order.Any())
                {
                    return ApiResponse<IEnumerable<OrderResponseDto>>.FailureResponse("No orders found for the specified customer.");
                }
                var orderDtos = _mapper.Map<IEnumerable<OrderResponseDto>>(order);
                return ApiResponse<IEnumerable<OrderResponseDto>>.SuccessResponse(orderDtos, "Orders retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<OrderResponseDto>>.FailureResponse($"An error occurred while retrieving orders. { ex.Message }");
            }
        }

        public async Task<ApiResponse<OrderResponseDto>> UpdateOrderStatusAsync(int id, UpdateOrderStatus statusDto)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(id);
                if (order == null)
                {
                    return ApiResponse<OrderResponseDto>.FailureResponse("Order not found.");
                }
                order.OrderStatus = statusDto.OrderStatus;
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.SaveChangesAsync();
                var orderDto = _mapper.Map<OrderResponseDto>(order);
                return ApiResponse<OrderResponseDto>.SuccessResponse(orderDto, "Order status updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<OrderResponseDto>.FailureResponse($"An error occurred while updating the order status. { ex.Message }");
            }

        }

    }
}
