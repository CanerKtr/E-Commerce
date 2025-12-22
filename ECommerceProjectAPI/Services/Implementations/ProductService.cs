using AutoMapper;
using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<BookResponseDto>> CreateBookAsync(BookRequestDto bookDto)
        {
            try
            {
                var book = _mapper.Map<BookProduct>(bookDto);
                book.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.Books.AddAsync(book);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<BookResponseDto>(book);
                response.ProductType = ProductCategoryType.Book;

                return ApiResponse<BookResponseDto>.SuccessResponse(response, "Book created successfully");

            }
            catch (Exception ex)
            {
                return ApiResponse<BookResponseDto>.FailureResponse($"An error occurred while creating the book. { ex.Message }");
            }
        }

        public async Task<ApiResponse<LaptopResponseDto>> CreateLaptopAsync(LaptopRequestDto laptopDto)
        {
            try
            {
                var laptop = _mapper.Map<LaptopProduct>(laptopDto);
                laptop.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.Laptops.AddAsync(laptop);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<LaptopResponseDto>(laptop);
                response.ProductType = ProductCategoryType.Laptop;

                return ApiResponse<LaptopResponseDto>.SuccessResponse(response, "Laptop created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<LaptopResponseDto>.FailureResponse($"An error occurred while creating the laptop. {ex.Message}");
            }
        }

        public async Task<ApiResponse<PhoneResponseDto>> CreatePhoneAsync(PhoneRequestDto phoneDto)
        {
            try
            {
                var phone = _mapper.Map<PhoneProduct>(phoneDto);
                phone.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.Phones.AddAsync(phone);
                await _unitOfWork.SaveChangesAsync();

                var response = _mapper.Map<PhoneResponseDto>(phone);
                response.ProductType = ProductCategoryType.Phone;

                return ApiResponse<PhoneResponseDto>.SuccessResponse(response, "Phone created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<PhoneResponseDto>.FailureResponse($"An error occurred while creating the phone. {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<bool>.FailureResponse("Product not found.");
                }
                product.IsActive = false;
                product.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Product deleted successfully.");

            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailureResponse($"An error occurred while deleting the product. {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllProductsAsync()
        {
            try
            {
                var products = await _unitOfWork.Products.GetAllAsync();
                var productDtos = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
                return ApiResponse<IEnumerable<ProductResponseDto>>.SuccessResponse(productDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ProductResponseDto>>.FailureResponse($"Error: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProductResponseDto>> GetProductByIdAsync(int productId)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(productId);
                if (product == null)
                {
                    return ApiResponse<ProductResponseDto>.FailureResponse("Product not found.");
                }
                var productDto = _mapper.Map<ProductResponseDto>(product);
                return ApiResponse<ProductResponseDto>.SuccessResponse(productDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductResponseDto>.FailureResponse($"An error occurred while retrieving the product. {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetProductsByCategoryAsync(ProductCategoryType categoryName)
        {
            try
            {
                var products = await _unitOfWork.Products.GetAllAsync();
                var filteredProducts = products.Where(p => p.ProductCategory == categoryName && p.IsActive == true);
                if(!filteredProducts.Any())
                    return ApiResponse<IEnumerable<ProductResponseDto>>.FailureResponse("No products found for the specified category.");

                var productDtos = _mapper.Map<IEnumerable<ProductResponseDto>>(filteredProducts);
                return ApiResponse<IEnumerable<ProductResponseDto>>.SuccessResponse(productDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ProductResponseDto>>.FailureResponse($"An error occurred while retrieving products by category. {ex.Message}");

            }
        }
        public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> SearchProductsAsync(string searchTerm, ProductCategoryType categoryName)
        {
            try
            {
                var productsResponse = await GetProductsByCategoryAsync(categoryName);

                if (!productsResponse.Success)
                {
                    return ApiResponse<IEnumerable<ProductResponseDto>>.FailureResponse(productsResponse.Message ?? "Failed to retrieve products for searching.");
                }

                var filteredProducts = productsResponse.Data!
                    .Where(p => p.Description!=null && p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) && p.IsActive == true)
                    .ToList(); 

                return ApiResponse<IEnumerable<ProductResponseDto>>.SuccessResponse(filteredProducts);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ProductResponseDto>>.FailureResponse($"An error occurred while searching products. {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProductResponseDto>> UpdateProductAsync(int id, UpdateProductRequestDto productDto)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<ProductResponseDto>.FailureResponse("Product not found.");
                }
                if (!string.IsNullOrEmpty(productDto.ProductName))
                    product.ProductName = productDto.ProductName;
                if (!string.IsNullOrEmpty(productDto.Description))
                    product.Description = productDto.Description;
                if (productDto.ProductPrice.HasValue)
                    product.ProductPrice = productDto.ProductPrice.Value;
                if (productDto.StockQuantity.HasValue)
                    product.StockQuantity = productDto.StockQuantity.Value;
                if (productDto.IsActive.HasValue)
                    product.IsActive = productDto.IsActive.Value;
                product.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveChangesAsync();
                var response = _mapper.Map<ProductResponseDto>(product);
                return ApiResponse<ProductResponseDto>.SuccessResponse(response, "Product updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductResponseDto>.FailureResponse($"An error occurred while updating the product. {ex.Message}");
            }
        }
    }
}
