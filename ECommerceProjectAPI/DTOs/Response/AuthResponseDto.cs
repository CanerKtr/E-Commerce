using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Response
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public UserRole UserRole { get; set; } 
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
