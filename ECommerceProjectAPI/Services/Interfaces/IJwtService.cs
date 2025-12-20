using ECommerceProjectAPI.Models;

namespace ECommerceProjectAPI.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string email, UserRole role);
    }
}
