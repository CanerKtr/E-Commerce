using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface IBranchService
    {
        Task<ApiResponse<BranchResponseDto>> GetBranchByIdAsync(int branchId);
        Task<ApiResponse<IEnumerable<BranchResponseDto>>> GetAllBranchesAsync();
        Task<ApiResponse<BranchResponseDto>> CreateBranchAsync(BranchRequestDto branchDto);
        Task<ApiResponse<BranchResponseDto>> UpdateBranchAsync(int branchId, BranchRequestDto branchDto);
        Task<ApiResponse<bool>> DeleteBranchAsync(int branchId);
    }
}
