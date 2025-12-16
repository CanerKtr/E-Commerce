namespace ECommerceProjectAPI.Models
{
    public abstract class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal ProductPrice { get; set; }
        public int StockQuantity { get; set; }
        public ProductCategoryType ProductCategory { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        // Employee Tracking Relationship
        public int? SalesPersonId { get; set; }
        public Employee TrackingBy { get; set; }
        // CartItems Relationship
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        // OrderItems Relationship
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


    }
    public enum ProductCategoryType
    {
        Phone,
        Laptop,
        Book
    }
}
