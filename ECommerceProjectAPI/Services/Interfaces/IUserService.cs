using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using System.Security.Claims;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<bool>> ChangePasswordAsync(int oldPassword, int newPassword, int newPasswordAgain);
        Task<ApiResponse<bool>> DeleteAddressAsync(int addressId);
        Task<ApiResponse<IEnumerable<AddressResponseDto>>> GetAllAddressesAsync();
        Task<ApiResponse<AddressResponseDto>> GetAddressByIdAsync(int addressId);
        Task<ApiResponse<AddressResponseDto>> CreateAddressAsync(AddressRequestDto addressDto);
        Task<ApiResponse<AddressResponseDto>> UpdateAddressAsync(int addressId, AddressUpdateRequestDto addressDto);
    }
}
