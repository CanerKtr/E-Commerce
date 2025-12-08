using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Request
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class RegisterRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public GenderType? GenderType { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty; 

    }
}
