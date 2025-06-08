using BG.Data.Models;
using BG.Models;
using HomePlanner.Entitites;

namespace HP.Service
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(LoginDto request);
        Task<TokenResponseDto?> RefreshToken(RefreshTokenDto request);
        Task<User> GetUserById(int id);
    }
}
