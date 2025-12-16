using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Response
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        public int TotalItems => Items.Sum(i => i.Quantity);
        public int CustomerId { get; set; }
        public List<OrderItemResponseDto> Items { get; set; } 
    }
    public class OrderItemResponseDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => (Quantity * UnitPrice) * ((100 - DiscountPercentage) / 100);
    }
}
