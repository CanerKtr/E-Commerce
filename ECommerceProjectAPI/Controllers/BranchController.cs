using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProjectAPI.Services.Implementations
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<BranchResponseDto>>>> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BranchResponseDto>>> GetBranchById(int branchId)
        {
            var branch = await _branchService.GetBranchByIdAsync(branchId);
            if (branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<BranchResponseDto>>> CreateBranch([FromBody] BranchRequestDto branchDto)
        {
            var result = await _branchService.CreateBranchAsync(branchDto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetBranchById), new { id = result.Data?.BranchId }, result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<BranchResponseDto>>> UpdateBranch(int branchId, [FromBody] BranchRequestDto branchDto)
        {
            var result = await _branchService.UpdateBranchAsync(branchId, branchDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteBranch(int branchId)
        {
            var result = await _branchService.DeleteBranchAsync(branchId);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}
