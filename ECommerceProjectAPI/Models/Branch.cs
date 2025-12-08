namespace ECommerceProjectAPI.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal? TotalSales { get; set; }

        // Branch Manager Relationship
        public int MgrId { get; set; }
        public Employee Manager { get; set; }
        // Employees in Branch Relationship
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
