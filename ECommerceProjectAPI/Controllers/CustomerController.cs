using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Employee), Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<ApiResponse<IEnumerable<CustomerResponseDto>>>> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomersAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = nameof(UserRole.Employee))]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> GetCustomerById(int id)
        {
            var result = await _customerService.GetCustomerByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpGet("email/{id}")]
        [Authorize(Roles = nameof(UserRole.Employee))]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> GetCustomerByEmail(string email)
        {
            var result = await _customerService.GetCustomerByEmailAsync(email);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> CreateCustomer(CreateCustomerRequestDto customerDto)
        {
            var result = await _customerService.CreateCustomerAsync(customerDto);
            if (!result.Success)
                { return BadRequest(result); }
            return CreatedAtAction(nameof(GetCustomerById), new {id = result.Data?.Id}, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Customer))]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> UpdateCustomer(int id,[FromBody] UpdateCustomerRequestDto customerDto)
        {
            var result = await _customerService.UpdateCustomerAsync(id, customerDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("admin/{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> AdminUpdateCustomer(int id, [FromBody] UpdateCustomerRequestDtoByAdmin customerDto)
        {
            var result = await _customerService.UpdateCustomerByAdminAsync(id, customerDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        



    }
}
