namespace ECommerceProjectAPI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }   
        public string ApartmentNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
