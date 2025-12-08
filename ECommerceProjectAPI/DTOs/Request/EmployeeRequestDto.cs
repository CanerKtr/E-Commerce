using ECommerceProjectAPI.Models;
namespace ECommerceProjectAPI.DTOs.Request
{
    public class CreateEmployeeRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal Salary { get; set; } = 0;
        public DateTime DateOfBirth { get; set; }
        public int BranchId { get; set; } 
        public int SupervisorId { get; set; }
        public Address Address { get; set; } = new Address();

    }
    public class UpdateEmployeeRequestDto
    {
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
    public class UpdateEmployeeRequestDtoByAdmin
    {
        public decimal? Salary { get; set; } 
        public int? SupervisorId { get; set; }
        public int? BranchId { get; set; }
    }
}
