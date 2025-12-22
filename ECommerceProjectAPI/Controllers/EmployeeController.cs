using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeResponseDto>>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeResponseDto>>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);

        }
        [HttpGet("branch/{branchId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeResponseDto>>>> GetEmployeesByBranchId(int branchId)
        {
            var employees = await _employeeService.GetEmployeesByBranchAsync(branchId);
            if (!employees.Success)
            {
                return NotFound(employees);
            }
            return Ok(employees);
        }


        [HttpPost("{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeResponseDto>>> CreateEmployee([FromBody] CreateEmployeeRequestDto employeeDto)
        {
            var result = await _employeeService.CreateEmployeeAsync(employeeDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(GetEmployeeById), new { id = result.Data?.Id }, result);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeResponseDto>>> UpdateEmployee(int id, [FromBody] UpdateEmployeeRequestDto employeeDto)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, employeeDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("admin/{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeResponseDto>>> UpdateEmployeeAsAdmin(int id, [FromBody] UpdateEmployeeRequestDtoByAdmin employeeDto)
        {
            var result = await _employeeService.UpdateEmployeeByAdminAsync(id, employeeDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

    }
}
