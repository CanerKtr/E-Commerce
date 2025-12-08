namespace ECommerceProjectAPI.DTOs.Request
{
    public class AddToCartRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class UpdateCartItemRequestDto
    {
        public int Quantity { get; set; }
    }
}
