using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ApiResponse<EmployeeResponseDto>> GetEmployeeByIdAsync(int employeeId);
        Task<ApiResponse<IEnumerable<EmployeeResponseDto>>> GetAllEmployeesAsync();
        Task<ApiResponse<EmployeeResponseDto>> CreateEmployeeAsync(CreateEmployeeRequestDto employeeDto);
        Task<ApiResponse<EmployeeResponseDto>> UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequestDto employeeDto);
        Task<ApiResponse<EmployeeResponseDto>> UpdateEmployeeByAdminAsync(int employeeId, UpdateEmployeeRequestDtoByAdmin employeeDto);
        Task<ApiResponse<bool>> DeleteEmployeeAsync(int employeeId);
        Task<ApiResponse<IEnumerable<EmployeeResponseDto>>> GetEmployeesByBranchAsync(int branchId);

    }
}
