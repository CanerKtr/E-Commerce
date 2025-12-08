namespace ECommerceProjectAPI.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        // Product CartItem Relationship
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Cart CartItem Relationship
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}