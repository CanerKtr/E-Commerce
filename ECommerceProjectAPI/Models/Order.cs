namespace ECommerceProjectAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

        // customer relationship
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // address relationship
        public int AddressId { get; set; }
        public Address Address { get; set; }

        // order items relationship
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
