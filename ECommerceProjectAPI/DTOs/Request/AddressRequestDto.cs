namespace ECommerceProjectAPI.DTOs.Request
{
    public class CreateAddressRequestDto
    {
        public string? AddressName { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string ApartmentNumber { get; set; } = string.Empty;
    }
    public class UpdateAddressDto : CreateAddressRequestDto
    {
        public int AddressId { get; set; }
    }
}
