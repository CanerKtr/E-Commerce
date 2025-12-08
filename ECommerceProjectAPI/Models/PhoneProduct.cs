namespace ECommerceProjectAPI.Models
{
    public class PhoneProduct: Product
    {
        public string Brand { get; set; }
        public int? StorageCapacityGB { get; set; }
        public int? CameraMegapixels { get; set; }
        public float? ScreenSizeInches { get; set; }
    }
}
