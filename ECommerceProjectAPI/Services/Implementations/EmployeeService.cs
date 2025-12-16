using AutoMapper;
using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<ApiResponse<IEnumerable<EmployeeResponseDto>>> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetAllAsync();
                var employeeDtos = new List<EmployeeResponseDto>();

                foreach (var employee in employees)
                {
                    var dto = _mapper.Map<EmployeeResponseDto>(employee);
                    var branch = await _unitOfWork.Branches.GetByIdAsync(employee.BranchId);
                    dto.BranchName = branch?.BranchName;

                    employeeDtos.Add(dto);
                }

                return ApiResponse<IEnumerable<EmployeeResponseDto>>.SuccessResponse(employeeDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<EmployeeResponseDto>>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<EmployeeResponseDto>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id);
                if (employee == null)
                    return ApiResponse<EmployeeResponseDto>.FailureResponse("Employee not found");

                var dto = _mapper.Map<EmployeeResponseDto>(employee);

                var branch = await _unitOfWork.Branches.GetByIdAsync(employee.BranchId);
                dto.BranchName = branch.BranchName;


                return ApiResponse<EmployeeResponseDto>.SuccessResponse(dto);
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<EmployeeResponseDto>> CreateEmployeeAsync(CreateEmployeeRequestDto employeeDto)
        {
            try
            {
                var existingEmployee = await _unitOfWork.Employees.AnyAsync(e => e.Email == employeeDto.Email);
                if (existingEmployee)
                    return ApiResponse<EmployeeResponseDto>.FailureResponse("Email already exists");

                var employee = _mapper.Map<Employee>(employeeDto);
                employee.Password = _authService.HashPassword(employeeDto.Password);
                employee.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.Employees.AddAsync(employee);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<EmployeeResponseDto>(employee);
                return ApiResponse<EmployeeResponseDto>.SuccessResponse(response, "Employee created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<EmployeeResponseDto>> UpdateEmployeeAsync(int id, UpdateEmployeeRequestDto employeeDto)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id);
                if (employee == null)
                    return ApiResponse<EmployeeResponseDto>.FailureResponse("Employee not found");

                _mapper.Map(employeeDto, employee);
                employee.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.Employees.Update(employee);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<EmployeeResponseDto>(employee);
                return ApiResponse<EmployeeResponseDto>.SuccessResponse(response, "Employee updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }
        public async Task<ApiResponse<EmployeeResponseDto>> UpdateEmployeeByAdminAsync(int id, UpdateEmployeeRequestDtoByAdmin employeeDto)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id);
                if (employee == null)
                    return ApiResponse<EmployeeResponseDto>.FailureResponse("Employee not found");
                _mapper.Map(employeeDto, employee);
                employee.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Employees.Update(employee);
                await _unitOfWork.SaveChangesAsync();
                var response = _mapper.Map<EmployeeResponseDto>(employee);
                return ApiResponse<EmployeeResponseDto>.SuccessResponse(response, "Employee updated successfully by admin");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id);
                if (employee == null)
                    return ApiResponse<bool>.FailureResponse("Employee not found");

                employee.IsActive = false;
                employee.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.Employees.Update(employee);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<EmployeeResponseDto>>> GetEmployeesByBranchAsync(int branchId)
        {
            try
            {
                var employees = await _unitOfWork.Employees.FindAsync(e => e.BranchId == branchId);
                var employeeDtos = _mapper.Map<IEnumerable<EmployeeResponseDto>>(employees);
                return ApiResponse<IEnumerable<EmployeeResponseDto>>.SuccessResponse(employeeDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<EmployeeResponseDto>>.FailureResponse($"Error: {ex.Message}");
            }
        }
    }
}