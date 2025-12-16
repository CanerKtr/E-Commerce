using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface ICartService
    {
        Task<ApiResponse<CartResponseDto>> GetCartByCustomerIdAsync(int customerId);
        Task<ApiResponse<IEnumerable<CartItemResponseDto>>> GetCartItemsAsync(int customerId);
        Task<ApiResponse<CartResponseDto>> AddToCartAsync(int customerId, AddToCartRequestDto addToCartDto);
        Task<ApiResponse<CartResponseDto>> UpdateCartItemAsync(int customerId, int cartItemId, UpdateCartItemRequestDto updateDto);
        Task<ApiResponse<bool>> RemoveFromCartAsync(int customerId, int cartItemId);
        Task<ApiResponse<bool>> ClearCartAsync(int customerId);
    }
}
