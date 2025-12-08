using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Response
{

    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public ProductCategoryType ProductType { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class BookResponseDto : ProductResponseDto
    {
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int? PageCount { get; set; }
        public string? Genre { get; set; }
    }

    public class PhoneResponseDto : ProductResponseDto
    {
        public string Brand { get; set; } = string.Empty;
        public double? ScreenSize { get; set; }
        public int? StorageCapacity { get; set; }
        public double? CameraMP { get; set; }
 
    }

    public class LaptopResponseDto : ProductResponseDto
    {
        public string? Processor { get; set; }
        public int? RAM { get; set; }
        public float? ScreenSize { get; set; }
    }

}
