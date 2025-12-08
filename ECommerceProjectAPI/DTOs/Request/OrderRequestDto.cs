using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Request
{
    public class CreateOrderRequestDto
    {
        public int AddressId { get; set; }
    }
    public class UpdateOrderStatus
    {
        public OrderStatus OrderStatus { get; set; }
    }
}
