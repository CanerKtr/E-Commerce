using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<ApiResponse<CartResponseDto>>> GetCartByCustomerId(int customerId)
        {
            var cart = await _cartService.GetCartByCustomerIdAsync(customerId);
            if (!cart.Success)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        [HttpGet("cartItems/{customerId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<CartItemResponseDto>>>> GetCartItemById(int cartItemId)
        {
            var cartItem = await _cartService.GetCartItemsAsync(cartItemId);
            if (!cartItem.Success)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CartResponseDto>>> AddToCart(int customerId,[FromBody] AddToCartRequestDto addToCartDto)
        {
            var result = await _cartService.AddToCartAsync(customerId, addToCartDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("{customerId}/items/{itemId}")]
        public async Task<ActionResult<ApiResponse<CartResponseDto>>> UpdateCart(int customerId, int itemId, [FromBody] UpdateCartItemRequestDto updateCartDto)
        {
            var result = await _cartService.UpdateCartItemAsync(customerId, itemId, updateCartDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{customerId}")]
        public async Task<ActionResult<ApiResponse<bool>>> ClearCart(int customerId)
        {
            var result = await _cartService.ClearCartAsync(customerId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{customerId}/items/{itemId}")]
        public async Task<ActionResult<ApiResponse<bool>>> RemoveFromCart(int customerId, int itemId)
        {
            var result = await _cartService.RemoveFromCartAsync(customerId, itemId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
