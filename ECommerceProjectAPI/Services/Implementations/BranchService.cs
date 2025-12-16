using AutoMapper;
using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class BranchService:IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<BranchResponseDto>>> GetAllBranchesAsync()
        {
            try
            {
                var branches = await _unitOfWork.Branches.GetAllAsync();
                var branchDtos = new List<BranchResponseDto>();

                foreach (var branch in branches)
                {
                    var dto = _mapper.Map<BranchResponseDto>(branch);
                    dto.EmployeeCount = await _unitOfWork.Employees.CountAsync(e => e.BranchId == branch.BranchId);
                    branchDtos.Add(dto);
                }

                return ApiResponse<IEnumerable<BranchResponseDto>>.SuccessResponse(branchDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<BranchResponseDto>>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<BranchResponseDto>> GetBranchByIdAsync(int id)
        {
            try
            {
                var branch = await _unitOfWork.Branches.GetByIdAsync(id);
                if (branch == null)
                    return ApiResponse<BranchResponseDto>.FailureResponse("Branch not found");

                var dto = _mapper.Map<BranchResponseDto>(branch);
                dto.EmployeeCount = await _unitOfWork.Employees.CountAsync(e => e.BranchId == branch.BranchId);

                return ApiResponse<BranchResponseDto>.SuccessResponse(dto);
            }
            catch (Exception ex)
            {
                return ApiResponse<BranchResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<BranchResponseDto>> CreateBranchAsync(BranchRequestDto branchDto)
        {
            try
            {
                var existingBranch = await _unitOfWork.Branches.AnyAsync(b => b.BranchName == branchDto.BranchName);
                if (existingBranch)
                    return ApiResponse<BranchResponseDto>.FailureResponse("Branch name already exists");

                var branch = _mapper.Map<Branch>(branchDto);

                await _unitOfWork.Branches.AddAsync(branch);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<BranchResponseDto>(branch);
                response.EmployeeCount = 0;

                return ApiResponse<BranchResponseDto>.SuccessResponse(response, "Branch created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<BranchResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<BranchResponseDto>> UpdateBranchAsync(int id, BranchRequestDto branchDto)
        {
            try
            {
                var branch = await _unitOfWork.Branches.GetByIdAsync(id);
                if (branch == null)
                    return ApiResponse<BranchResponseDto>.FailureResponse("Branch not found");

                var existingBranch = await _unitOfWork.Branches.AnyAsync(b => b.BranchName == branchDto.BranchName && b.BranchId != id);
                if (existingBranch)
                    return ApiResponse<BranchResponseDto>.FailureResponse("Branch name already exists");

                _mapper.Map(branchDto, branch);

                _unitOfWork.Branches.Update(branch);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<BranchResponseDto>(branch);
                response.EmployeeCount = await _unitOfWork.Employees.CountAsync(e => e.BranchId == branch.BranchId);

                return ApiResponse<BranchResponseDto>.SuccessResponse(response, "Branch updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<BranchResponseDto>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteBranchAsync(int id)
        {
            try
            {
                var branch = await _unitOfWork.Branches.GetByIdAsync(id);
                if (branch == null)
                    return ApiResponse<bool>.FailureResponse("Branch not found");

                branch.IsActive = false;
                _unitOfWork.Branches.Update(branch);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Branch deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"Error: {ex.Message}");
            }
        }
    }
}