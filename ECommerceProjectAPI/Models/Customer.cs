namespace ECommerceProjectAPI.Models
{
    public class Customer: User
    {
        public decimal? Balance { get; set; }
        public CustomerLevelType CustomerLevel { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
    public enum CustomerLevelType
    {
        Standard,
        Premium,
        Vip
    }
}
