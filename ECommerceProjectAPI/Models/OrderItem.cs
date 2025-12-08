namespace ECommerceProjectAPI.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercentage { get; set; } = 1;
        public decimal TotalPrice => (Quantity*UnitPrice)*((100-DiscountPercentage)/100);
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
