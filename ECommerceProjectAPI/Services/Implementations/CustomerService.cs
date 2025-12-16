using AutoMapper;
using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }
        public async Task<ApiResponse<IEnumerable<CustomerResponseDto>>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _unitOfWork.Customers.GetAllAsync();
                var customerDtos = _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);
                return ApiResponse<IEnumerable<CustomerResponseDto>>.SuccessResponse(customerDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CustomerResponseDto>>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CustomerResponseDto>> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null)
                    return ApiResponse<CustomerResponseDto>.FailureResponse("Customer not found");

                var customerDto = _mapper.Map<CustomerResponseDto>(customer);
                return ApiResponse<CustomerResponseDto>.SuccessResponse(customerDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CustomerResponseDto>> CreateCustomerAsync(CreateCustomerRequestDto customerDto)
        {
            try
            {
                var existingCustomer = await _unitOfWork.Customers.AnyAsync(c => c.Email == customerDto.Email);
                if (existingCustomer)
                    return ApiResponse<CustomerResponseDto>.FailureResponse("Email already exists");

                var customer = _mapper.Map<Customer>(customerDto);
                customer.Password = _authService.HashPassword(customerDto.Password);
                customer.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.Customers.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<CustomerResponseDto>(customer);
                return ApiResponse<CustomerResponseDto>.SuccessResponse(response, "Customer created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CustomerResponseDto>> UpdateCustomerAsync(int id, UpdateCustomerRequestDto customerDto)
        {
            try
            {
                // JWT ile doğrulama eklenecektir.
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null)
                    return ApiResponse<CustomerResponseDto>.FailureResponse("Customer not found");

                _mapper.Map(customerDto, customer);
                customer.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.Customers.Update(customer);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<CustomerResponseDto>(customer);
                return ApiResponse<CustomerResponseDto>.SuccessResponse(response, "Customer updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }
        public async Task<ApiResponse<CustomerResponseDto>> UpdateCustomerByAdminAsync(int id, UpdateCustomerRequestDtoByAdmin customerDto)
        {
            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null)
                    return ApiResponse<CustomerResponseDto>.FailureResponse("Customer not found");
                _mapper.Map(customerDto, customer);
                customer.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Customers.Update(customer);
                await _unitOfWork.SaveChangesAsync();
                var response = _mapper.Map<CustomerResponseDto>(customer);
                return ApiResponse<CustomerResponseDto>.SuccessResponse(response, "Customer updated successfully by admin");
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null)
                    return ApiResponse<bool>.FailureResponse("Customer not found");

                customer.IsActive = false;
                customer.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.Customers.Update(customer);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Customer deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CustomerResponseDto>> GetCustomerByEmailAsync(string email)
        {
            try
            {
                var customer = await _unitOfWork.Customers.FirstOrDefaultAsync(c => c.Email == email);
                if (customer == null)
                    return ApiResponse<CustomerResponseDto>.FailureResponse("Customer not found");

                var customerDto = _mapper.Map<CustomerResponseDto>(customer);
                return ApiResponse<CustomerResponseDto>.SuccessResponse(customerDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }
    }
}
