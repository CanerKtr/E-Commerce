using AutoMapper;
using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<bool>> ChangePasswordAsync(int oldPassword, int newPassword, int newPasswordAgain)
        {
            try
            {
                await Task.Delay(10); // Simulating async work
                // we'll implement password change logic here
                if (newPassword != newPasswordAgain)
                    return ApiResponse<bool>.FailureResponse("New passwords do not match");


                return ApiResponse<bool>.SuccessResponse(true, "Password changed successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"An error occurred while changing the password. {ex.Message}");
            }



        }

        public async Task<ApiResponse<AddressResponseDto>> CreateAddressAsync(AddressRequestDto addressDto)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDto);
                await _unitOfWork.Addresses.AddAsync(address);
                await _unitOfWork.SaveChangesAsync();
                var addressResponse = _mapper.Map<AddressResponseDto>(address);
                return ApiResponse<AddressResponseDto>.SuccessResponse(addressResponse, "Address created successfully");

            }
            catch (Exception ex)
            {
                return ApiResponse<AddressResponseDto>.FailureResponse($"An error occurred while creating the address. {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteAddressAsync(int addressId)
        {
            try
            {
                var address = await _unitOfWork.Addresses.GetByIdAsync(addressId);
                if (address == null)
                    return ApiResponse<bool>.FailureResponse("Address not found");
                _unitOfWork.Addresses.Remove(address);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Address deleted successfully");
            }
            catch
            (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"An error occurred while deleting the address. {ex.Message}");
            }
        }

        public async Task<ApiResponse<AddressResponseDto>> GetAddressByIdAsync(int addressId)
        {
            try
            {
                var address = await _unitOfWork.Addresses.GetByIdAsync(addressId);
                if (address == null)
                    return ApiResponse<AddressResponseDto>.FailureResponse("Address not found");
                var addressResponse = _mapper.Map<AddressResponseDto>(address);
                return ApiResponse<AddressResponseDto>.SuccessResponse(addressResponse, "Address retrieved successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<AddressResponseDto>.FailureResponse($"An error occurred while retrieving the address. {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AddressResponseDto>>> GetAllAddressesAsync()
        {
            try 
            {
                var addresses = await _unitOfWork.Addresses.GetAllAsync();
                if(!addresses.Any())
                    return ApiResponse<IEnumerable<AddressResponseDto>>.FailureResponse("No addresses found");
                var addressResponses = _mapper.Map<IEnumerable<AddressResponseDto>>(addresses);
                return ApiResponse<IEnumerable<AddressResponseDto>>.SuccessResponse(addressResponses, "Addresses retrieved successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AddressResponseDto>>.FailureResponse($"An error occurred while retrieving addresses. {ex.Message}");
            }
        }

        public async Task<ApiResponse<AddressResponseDto>> UpdateAddressAsync(int addressId, AddressUpdateRequestDto addressDto)
        {
            try
            {
                var address = await _unitOfWork.Addresses.GetByIdAsync(addressId);
                if (address == null)
                    return ApiResponse<AddressResponseDto>.FailureResponse("Address not found");
                _mapper.Map(addressDto, address);
                _unitOfWork.Addresses.Update(address);
                await _unitOfWork.SaveChangesAsync();
                var addressResponse = _mapper.Map<AddressResponseDto>(address);
                return ApiResponse<AddressResponseDto>.SuccessResponse(addressResponse, "Address updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<AddressResponseDto>.FailureResponse($"An error occurred while updating the address. {ex.Message}");
            }
        }

    }
}
