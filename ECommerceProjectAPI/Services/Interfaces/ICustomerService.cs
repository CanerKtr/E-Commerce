using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ApiResponse<CustomerResponseDto>> GetCustomerByIdAsync(int customerId);
        Task<ApiResponse<IEnumerable<CustomerResponseDto>>> GetAllCustomersAsync();
        Task<ApiResponse<CustomerResponseDto>> CreateCustomerAsync(CreateCustomerRequestDto customerDto);
        Task<ApiResponse<CustomerResponseDto>> UpdateCustomerAsync(int customerId, UpdateCustomerRequestDto customerDto);
        Task<ApiResponse<CustomerResponseDto>> UpdateCustomerByAdminAsync(int customerId, UpdateCustomerRequestDtoByAdmin customerDto); 
        Task<ApiResponse<bool>> DeleteCustomerAsync(int customerId);
        Task<ApiResponse<CustomerResponseDto>> GetCustomerByEmailAsync(string email);

    }
}
