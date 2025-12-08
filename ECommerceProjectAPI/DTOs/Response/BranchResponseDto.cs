namespace ECommerceProjectAPI.DTOs.Response
{
    public class BranchResponseDto
    {
        public int MgrId { get; set; }
        public string BrarnchName { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public bool IsActive { get; set; }
        public int EmployeeCount { get; set; }
    }
}
