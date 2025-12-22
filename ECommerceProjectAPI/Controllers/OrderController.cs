using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<OrderResponseDto>>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<ApiResponse<OrderResponseDto>>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (!order.Success)
            {
                return NotFound(order);
            }
            return Ok(order);
        }
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<OrderResponseDto>>>> GetOrderByCustomerId(int id)
        {
            var orders = await _orderService.GetOrdersByCustomerIdAsync(id);
            if(!orders.Success)
                return NotFound(orders);
            return Ok(orders);
        }


        [HttpPost("{id}")]
        public async Task<ActionResult<ApiResponse<OrderResponseDto>>> CreateOrder(int id, [FromBody] CreateOrderRequestDto orderDto)
        {
            var result = await _orderService.CreateOrderAsync(id, orderDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Data?.OrderId }, result);
        }
        [HttpPut("status/{id}")]
        public async Task<ActionResult<ApiResponse<OrderResponseDto>>> UpdateOrder(int id, [FromBody] UpdateOrderStatus orderDto)
        {
            var result = await _orderService.UpdateOrderStatusAsync(id, orderDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("cancel/{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> CancelOrder(int id)
        {
            var result = await _orderService.CancelOrderAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
