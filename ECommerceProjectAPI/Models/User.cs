using System.Net;

namespace ECommerceProjectAPI.Models
{
    public abstract class User
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public GenderType? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } 
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
    public enum UserRole
    {
        Customer,
        Employee,
        Admin
    }
    public enum GenderType
    {
        M,
        F
    }
}
