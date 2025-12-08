using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.DTOs.Response
{
    public class AdminResponseDto
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public GenderType? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
