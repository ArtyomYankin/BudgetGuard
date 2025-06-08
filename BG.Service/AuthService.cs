using BG.Data.Models;
using BG.Models;
using BG.Repository.Auth;
using BG.Service.JWTService;
using HomePlanner.Entitites;
using Microsoft.Extensions.Configuration;

namespace HP.Service
{
    public class AuthService(IConfiguration configuration, IAuthRepository _authRepository, IJwtService jwtService) : IAuthService
    {
        public async Task<User?> RegisterAsync(UserDto request)
        {
            if (await _authRepository.CheckIfEmailTaken(request.Email))
            {
                return null;
            }
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password) // Хеширование пароля
            };

            await _authRepository.RegisterAsync(user);
            return user;
        }

        public async Task<TokenResponseDto?> LoginAsync(LoginDto request)
        {
            var user = await _authRepository.LoginUserAsync(request);
            if (user == null)
            {
                return null;
            }
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return null;

            var token = jwtService.GenerateToken(user);

            // Обновляем Refresh Token (если нужно)
            user.RefreshToken = Guid.NewGuid().ToString();
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _authRepository.SaveChangesAsync();
            return new TokenResponseDto()
            {
                RefreshToken = user.RefreshToken,
                Token = token,
                User = new UserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                }
            };
        }

        public async Task<TokenResponseDto?> RefreshToken(RefreshTokenDto request)
        {
            var user = await _authRepository.GetUserByTokenAsync(request.RefreshToken);
            if (user == null || user.RefreshTokenExpiry < DateTime.UtcNow)
                return null;

            var newToken = jwtService.GenerateToken(user);
            user.RefreshToken = Guid.NewGuid().ToString(); // Генерируем новый Refresh Token
            await _authRepository.SaveChangesAsync();


            return new TokenResponseDto()
            {
                RefreshToken = user.RefreshToken,
                Token = newToken
            };
        }

        public Task<User> GetUserById(int id)
        {
            return _authRepository.GetUserAsync(id);
        }
    }
}
