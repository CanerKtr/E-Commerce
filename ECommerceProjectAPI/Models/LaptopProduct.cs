namespace ECommerceProjectAPI.Models
{
    public class LaptopProduct : Product
    {
        public string Processor { get; set; }
        public int? RamSizeGB { get; set; }
        public float? ScreenSizeInches { get; set; }
    }
}
