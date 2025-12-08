namespace ECommerceProjectAPI.Models
{
    public class BookProduct : Product
    {
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int? PageCount { get; set; }
        public string? Genre { get; set; }
    }
}
