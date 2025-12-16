using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponseDto>> GetProductByIdAsync(int productId);
        Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllProductsAsync();
        Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetProductsByCategoryAsync(ProductCategoryType categoryName);
        Task<ApiResponse<IEnumerable<ProductResponseDto>>> SearchProductsAsync(string searchTerm, ProductCategoryType categoryName);
        Task<ApiResponse<BookResponseDto>> CreateBookAsync(BookRequestDto bookDto);
        Task<ApiResponse<PhoneResponseDto>> CreatePhoneAsync(PhoneRequestDto phoneDto);
        Task<ApiResponse<LaptopResponseDto>> CreateLaptopAsync(LaptopRequestDto laptopDto);
        Task<ApiResponse<ProductResponseDto>> UpdateProductAsync(int id, UpdateProductRequestDto productDto);
        Task<ApiResponse<bool>> DeleteProductAsync(int id);
    }
}
