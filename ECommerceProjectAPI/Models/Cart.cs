namespace ECommerceProjectAPI.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        // Cart Items Relationship
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
