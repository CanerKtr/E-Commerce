using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Request
{
    public class CreateCustomerRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; } = 0;
        public CustomerLevelType? CustomerLevelType { get; set; }  
        public List<AddressRequestDto> Addresses { get; set; } = new List<AddressRequestDto>();

    }
    public class UpdateCustomerRequestDto
    {
        public string? Email { get; set; } 
        public string? PhoneNumber { get; set; } 
        public decimal? Balance { get; set; } 
    }
    public class UpdateCustomerRequestDtoByAdmin : UpdateCustomerRequestDto
    {
        public CustomerLevelType? CustomerLevelType { get; set; }

    }

}
