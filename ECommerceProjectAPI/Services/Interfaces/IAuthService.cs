using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto loginDto);
        public Task<ApiResponse<CustomerResponseDto>> RegisterCustomerAsync(RegisterRequestDto registerDto);
        public string GenerateJwtToken(int userId, string email);
        public string HashPassword(string password);
        public bool VerifyPassword(string password, string passwordHash);
    }
}
