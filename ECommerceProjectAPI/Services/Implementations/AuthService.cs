using ECommerceProjectAPI.DTOs.Request;
using ECommerceProjectAPI.DTOs.Response;
using ECommerceProjectAPI.Models;
using ECommerceProjectAPI.Repository.Interfaces;
using ECommerceProjectAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceProjectAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = await _unitOfWork.Users.FirstOrDefaultAsync(c => c.Email == loginRequestDto.Email);
                if (user != null && VerifyPassword(loginRequestDto.Password,user.Password))
                {
                    var token = GenerateJwtToken(user.UserId, user.Email);
                    var loginResponse = new LoginResponseDto
                    {
                        Token = token,
                        UserRole = user.Role,
                        UserId = user.UserId,
                        Email = user.Email,
                        FullName = $"{user.UserFirstName} {user.UserLastName}"
                    };
                    return ApiResponse<LoginResponseDto>.SuccessResponse(loginResponse, "Login successful.");
                }
                return ApiResponse<LoginResponseDto>.FailureResponse("Invalid email or password");
            }
            catch(Exception ex)
            {
                return ApiResponse<LoginResponseDto>.FailureResponse($"An error occurred during login. { ex.Message }");
            }
        }
        public async Task<ApiResponse<CustomerResponseDto>> RegisterCustomerAsync(RegisterRequestDto registerDto)
        {
            try
            {
                var existingUser = await _unitOfWork.Users.AnyAsync(c => c.Email == registerDto.Email);
                if (existingUser)
                    return ApiResponse<CustomerResponseDto>.FailureResponse("Email already registered");
                // admin ve employee kaydı yapılamaz sadece customer kayıt yapabilir.
                var customer = new Customer
                {
                    UserFirstName = registerDto.FirstName,
                    UserLastName = registerDto.LastName,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber,
                    Password = HashPassword(registerDto.Password),
                    CustomerLevel = CustomerLevelType.Standard,
                    Role = UserRole.Customer,
                    Balance = 0,
                    DateOfBirth = registerDto.DateOfBirth,
                    CreatedAt = DateTime.UtcNow,
                    Gender = registerDto.GenderType,
                };

                await _unitOfWork.Customers.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                var response = new CustomerResponseDto
                {
                    Id = customer.UserId,
                    FirstName = customer.UserFirstName,
                    LastName = customer.UserLastName,
                    Email = customer.Email,
                    Phone = customer.PhoneNumber,
                    LevelType = customer.CustomerLevel,
                    DateOfBirth = customer.DateOfBirth,
                    CreatedAt = customer.CreatedAt
                };

                return ApiResponse<CustomerResponseDto>.SuccessResponse(response, "Registration successful");
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerResponseDto>.FailureResponse($"Registration failed: {ex.Message}");
            }
        }

        public string GenerateJwtToken(int userId, string email)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"] ?? throw new InvalidOperationException("JWT Secret Key not configured");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpirationMinutes"] ?? "60")),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == passwordHash;
        }
    }
}
