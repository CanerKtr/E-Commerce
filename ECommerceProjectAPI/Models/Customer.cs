namespace ECommerceProjectAPI.Models
{
    public class Customer: User
    {
        public decimal? Balance { get; set; }
        public customerLevelType CustomerLevel { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
    public enum customerLevelType
    {
        Standard,
        Premium,
        Vip
    }
}
