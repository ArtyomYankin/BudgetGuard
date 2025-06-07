using BG.Data;
using BG.Data.Models;
using HomePlanner.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Repository.Auth
{
    public class AuthRepository(AppDbContext context) : IAuthRepository
    {
        public async Task<bool> CheckIfEmailTaken(string email)
        {
            if (await context.Users.AnyAsync(u => u.Email == email))
            {
                return true;
            }
            return false;
        }

        public async Task<User?> GetUserAsync(int userId)
        {
            return await context.Users.FirstOrDefaultAsync(u=>u.Id == userId);
        }

        public async Task<User?> GetUserByTokenAsync(string refreshToken)
        {
            var user = await context.Users.FirstOrDefaultAsync(u=>u.RefreshToken == refreshToken);
            if (user == null) 
            {
                return null;
            }

            return user;
        }

        public async Task<User?> LoginUserAsync(LoginDto request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null) 
                return null;

            return user;
        }

        public async Task<User?> RegisterAsync(User newUser)
        {
            context.Users.Add(newUser);
            await SaveChangesAsync();
            return newUser;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
