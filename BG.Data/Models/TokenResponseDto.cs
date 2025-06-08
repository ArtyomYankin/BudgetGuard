using BG.Models;

namespace BG.Data.Models
{
    public class TokenResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public UserDto User { get; set; }
    }
}
