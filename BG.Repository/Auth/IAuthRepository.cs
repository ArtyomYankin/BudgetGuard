using BG.Data.Models;
using HomePlanner.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Repository.Auth
{
    public interface IAuthRepository
    {
        public Task<User?> RegisterAsync(User request);
        public Task<User?> LoginUserAsync(LoginDto request);
        public Task<User?> GetUserAsync(int userId);
        public Task<bool> CheckIfEmailTaken(string email);
        public Task<User?> GetUserByTokenAsync(string refreshToken);
        public Task SaveChangesAsync();
    }
}
