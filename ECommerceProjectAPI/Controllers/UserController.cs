using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("password")]
        public async Task<ActionResult<ApiResponse<bool>>> ChangePassword(int oldPass, int newPass, int newPassAgain)
        {
            var result = await _userService.ChangePasswordAsync(oldPass, newPass, newPassAgain);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<AddressResponseDto>>>> GetAllAddresses()
        {
            var address = await _userService.GetAllAddressesAsync();
            if (!address.Success)
                return BadRequest(address);
            return Ok(address);
        }

        [HttpGet("address/{addressId}")]
        public async Task<ActionResult<ApiResponse<AddressResponseDto>>> GetAddressById(int addressId)
        {
            var address = await _userService.GetAddressByIdAsync(addressId);
            if (!address.Success)
                return BadRequest(address);
            return Ok(address);
        }

        [HttpDelete("address/{addressId}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAddress(int addressId)
        {
            var result = await _userService.DeleteAddressAsync(addressId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);


        }

        [HttpPost("address")]
        public async Task<ActionResult<ApiResponse<AddressResponseDto>>> CreateAddress([FromBody] AddressRequestDto createAddressDto)
        {
            var result = await _userService.CreateAddressAsync(createAddressDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("address")]
        public async Task<ActionResult<ApiResponse<AddressResponseDto>>> UpdateAddress(int addressId, [FromBody] AddressUpdateRequestDto updateAddressDto)
        {
            var result = await _userService.UpdateAddressAsync(addressId, updateAddressDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
