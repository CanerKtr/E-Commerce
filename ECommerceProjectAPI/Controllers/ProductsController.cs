using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductResponseDto>>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            if (!products.Success)
            {
                return BadRequest(products);
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (!product.Success)
            {
                return NotFound(product);
            }
            return Ok(product);
        }

        [HttpGet("filter/category/{category}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductResponseDto>>>> GetProductsByCategory(ProductCategoryType category)
        {
            var products = await _productService.GetProductsByCategoryAsync(category);
            if (!products.Success)
                return NotFound(products);
            return Ok(products);
        }

        [HttpGet("search/category/{category}/search/{search}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductResponseDto>>>> SearchProducts(ProductCategoryType category, string search)
        {
            var filteredProducts = await _productService.SearchProductsAsync(search,category);
            if(!filteredProducts.Success)
                return BadRequest(filteredProducts);
            return Ok(filteredProducts);
        }

        [HttpPost("create/book")]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> CreateBookProduct([FromBody] BookRequestDto createBookDto)
        {
            var result = await _productService.CreateBookAsync(createBookDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("create/phone")]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> CreatePhoneProduct([FromBody] PhoneRequestDto createPhoneDto)
        {
            var result = await _productService.CreatePhoneAsync(createPhoneDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("create/laptop")]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> CreateLaptopProduct([FromBody] LaptopRequestDto createLaptopDto)
        {
            var result = await _productService.CreateLaptopAsync(createLaptopDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> UpdateProduct(int id, [FromBody] UpdateProductRequestDto updateProductDto)
        {
            var result = await _productService.UpdateProductAsync(id, updateProductDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
