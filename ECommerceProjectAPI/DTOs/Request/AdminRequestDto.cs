using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Request
{
    public class AdminRequestDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public GenderType? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Address Address = new Address();
    }
    public class UpdateAdminRequestDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public GenderType? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DateOfBirth { get; set; }
    }
}
