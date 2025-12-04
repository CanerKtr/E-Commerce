using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ECommerceProjectAPI.Models
{
    public class Employee: User
    {
        public decimal Salary { get; set; }
        public decimal? TotalSales { get; set; }
        // Employee Supervisor Relationship
        public int? SupervisorId { get; set; }
        public Employee Supervisor { get; set; }
        public ICollection<Employee> SupervisorOf { get; set; } = new List<Employee>();


        // Employee Branch Relationship
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }

        // Branch Employee Manager Relationship
        public ICollection<Branch> ManagedBranches { get; set; } = new List<Branch>();

        // Products Tracking Relationship
        public ICollection<Product> TrackedProducts { get; set; } = new List<Product>();
    }
}
