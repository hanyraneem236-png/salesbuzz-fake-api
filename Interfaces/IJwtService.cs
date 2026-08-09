using SalesBuzz.API.Models;

namespace SalesBuzz.API.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}