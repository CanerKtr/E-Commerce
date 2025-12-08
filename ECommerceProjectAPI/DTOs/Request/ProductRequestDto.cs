using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Request
{
    public class ProductRequestDto
    {
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal ProductPrice { get; set; }
        public int StockQuantity { get; set; }
        public ProductCategoryType ProductCategory { get; set; }
        public bool IsActive { get; set; }
        public int? SalesPersonId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
    }
    public class BookRequestDto : ProductRequestDto
    {
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int? PageCount { get; set; }
        public string? Genre { get; set; }

    }
    public class PhoneRequestDto: ProductRequestDto 
    {
        public string Brand { get; set; }
        public int? StorageCapacityGB { get; set; }
        public int? CameraMegapixels { get; set; }
        public float? ScreenSizeInches { get; set; }

    }
    public class LaptopRequestDto: ProductRequestDto
    {
        public string Processor { get; set; } = string.Empty;
        public int? RamSizeGB { get; set; }
        public float? ScreenSizeInches { get; set; }
    }

}
