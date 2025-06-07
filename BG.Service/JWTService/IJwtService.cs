using HomePlanner.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BG.Service.JWTService
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        public ClaimsPrincipal ValidateToken(string token);
    }
}
