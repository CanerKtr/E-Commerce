using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetAllOrdersAsync();
        Task<ApiResponse<OrderResponseDto>> GetOrderByIdAsync(int id);
        Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetOrdersByCustomerIdAsync(int customerId);
        Task<ApiResponse<OrderResponseDto>> CreateOrderAsync(int customerId, CreateOrderRequestDto orderDto);
        Task<ApiResponse<OrderResponseDto>> UpdateOrderStatusAsync(int id, UpdateOrderStatus statusDto);
        Task<ApiResponse<bool>> CancelOrderAsync(int id);
        Task<ApiResponse<bool>> DeleteOrderAsync(int id);
    }
}
