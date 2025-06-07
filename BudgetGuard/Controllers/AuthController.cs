using BG.Data.Models;
using BG.Models;
using BG.Service.JWTService;
using HomePlanner.Entitites;
using HP.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HopePlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService, IJwtService _jwtService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authService.RegisterAsync(request);
            if (user == null)
                return BadRequest("Username already exists.");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);
            if (response == null)
                return Unauthorized("Неверный email или пароль.");

            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            var response = await _authService.RefreshToken(dto);
            if (response == null)
                return Unauthorized("Недействительный Refresh Token.");

            return Ok(response);
        }
    }
    
}
