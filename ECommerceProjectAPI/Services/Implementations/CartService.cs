using AutoMapper;
using ECommerceProjectAPI.Data;
using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Implementations;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ApiResponse<CartResponseDto>> AddToCartAsync(int customerId, AddToCartRequestDto addToCartDto)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(addToCartDto.ProductId);
                if (product == null)
                {
                    return ApiResponse<CartResponseDto>.FailureResponse("Product not found.");
                }
                if (product.StockQuantity < addToCartDto.Quantity)
                {
                    return ApiResponse<CartResponseDto>.FailureResponse("Insufficient stock for the requested product.");
                }
                var cart = await _context.Carts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);
                if (cart == null)
                {
                    cart = new Cart
                    {
                        CustomerId = customerId,
                        Items = new List<CartItem>()
                    };
                    await _unitOfWork.Carts.AddAsync(cart);
                    await _unitOfWork.SaveChangesAsync();
                }
                var existingCartItem = cart.Items.FirstOrDefault(ci => ci.ProductId == addToCartDto.ProductId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += addToCartDto.Quantity;
                    _unitOfWork.CartItems.Update(existingCartItem);
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        ProductId = addToCartDto.ProductId,
                        Quantity = addToCartDto.Quantity,
                        UnitPrice = product.ProductPrice,
                        CartId = cart.CartId
                    };
                    await _unitOfWork.CartItems.AddAsync(cartItem);
                }
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<CartResponseDto>.SuccessResponse(_mapper.Map<CartResponseDto>(cart), "Item added to cart successfully.");

            }
            catch (Exception ex)
            {
                return ApiResponse<CartResponseDto>.FailureResponse("An error occurred while adding item to cart.", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> ClearCartAsync(int customerId)
        {
            try
            {
                var cart = await _context.Carts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);

                if (cart == null)
                {
                    return ApiResponse<bool>.FailureResponse("Cart not found for the specified customer.");
                }
                _unitOfWork.CartItems.RemoveRange(cart.Items);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"An error occurred while clearing the cart. {ex.Message}");
            }
        }

        public async Task<ApiResponse<CartResponseDto>> GetCartByCustomerIdAsync(int customerId)
        {
            try
            {
                var cart = await _context.Carts
                    .Include(c => c.Items)
                    .ThenInclude(ci => ci.Product)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);
                if (cart == null)
                {
                    return ApiResponse<CartResponseDto>.FailureResponse("Cart not found for the specified customer.");
                }
                var cartDto = _mapper.Map<CartResponseDto>(cart);
                return ApiResponse<CartResponseDto>.SuccessResponse(cartDto, "Cart retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<CartResponseDto>.FailureResponse("An error occurred while retrieving the cart.", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<CartItemResponseDto>>> GetCartItemsAsync(int customerId)
        {
            try
            {
                var cartItems = await _context.CartItems
                    .Include(ci => ci.Cart)
                    .Include(ci => ci.Product)
                    .Where(ci => ci.Cart.CustomerId == customerId)
                    .ToListAsync();
                if (!cartItems.Any())
                {
                    return ApiResponse<IEnumerable<CartItemResponseDto>>.FailureResponse("No cart items found for the specified customer.");
                }
                var cartItemDtos = _mapper.Map<IEnumerable<CartItemResponseDto>>(cartItems);
                return ApiResponse<IEnumerable<CartItemResponseDto>>.SuccessResponse(cartItemDtos, "Cart items retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CartItemResponseDto>>.FailureResponse($"An error occurred while retrieving cart items. {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> RemoveFromCartAsync(int customerId, int cartItemId)
        {
            try
            {
                var cartItem = await _context.CartItems
                    .Include(c => c.Cart)
                    .FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId && ci.Cart.CustomerId == customerId);
                if (cartItem == null)
                {
                    return ApiResponse<bool>.FailureResponse("Cart item not found for the specified customer.");
                }
                _unitOfWork.CartItems.Remove(cartItem);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Item removed from cart successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"An error occurred while removing item from cart. {ex.Message}");
            }

        }

        public async Task<ApiResponse<CartResponseDto>> UpdateCartItemAsync(int customerId, int cartItemId, UpdateCartItemRequestDto updateDto)
        {
            try
            {
                var cartItem = await _context.CartItems
                    .Include(ci => ci.Cart)
                    .Include(p => p.Product)
                    .FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId && ci.Cart.CustomerId == customerId);
                if (cartItem == null)
                {
                    return ApiResponse<CartResponseDto>.FailureResponse("Cart item not found for the specified customer.");
                }
                if (updateDto.Quantity < 0)
                {
                    return ApiResponse<CartResponseDto>.FailureResponse("Quantity must be greater than or equal to zero.");
                }
                if (updateDto.Quantity == 0)
                {
                    await RemoveFromCartAsync(cartItem.Cart.CustomerId, cartItem.CartItemId);
                    var response = _mapper.Map<CartResponseDto>(cartItem.Cart);
                    return ApiResponse<CartResponseDto>.SuccessResponse(response, "Item removed from cart as quantity was set to zero.");
                }
                if (cartItem.Product.StockQuantity < updateDto.Quantity)
                {
                    return ApiResponse<CartResponseDto>.FailureResponse("Insufficient stock for the requested product.");
                }
                cartItem.Quantity = updateDto.Quantity;
                _unitOfWork.CartItems.Update(cartItem);
                await _unitOfWork.SaveChangesAsync();
                var response = _mapper.Map<CartResponseDto>(cartItem.Cart);
                return ApiResponse<CartResponseDto>.SuccessResponse(response , "Cart item updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<CartResponseDto>.FailureResponse($"An error occurred while updating cart item. {ex.Message}");
            }
        }
    }
}
