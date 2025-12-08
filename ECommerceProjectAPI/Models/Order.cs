namespace ECommerceProjectAPI.Models
{
    public class Order
    {
        public int OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);

        // customer relationship
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

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
