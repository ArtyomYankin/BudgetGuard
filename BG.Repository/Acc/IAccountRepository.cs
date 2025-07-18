﻿using BG.Data.Entitites;
namespace BG.Repository.Acc
{
    public interface IAccountRepository
    {
        Task<UserAccount> GetAccount(int id);
        Task<UserAccount> AddAccount(UserAccount account);
        Task<UserAccount> UpdateAccount(UserAccount account);
        Task<bool> RemoveAccount(int id);
        Task<List<UserAccount>> GetAllUserAccounts(int userId);
    }
}
