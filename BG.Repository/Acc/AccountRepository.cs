using BG.Data;
using BG.Data.Entitites;
using BG.Repository.Acc;

namespace BG.Repository.Account
{
    public class AccountRepository(AppDbContext _appDbContext) : IAccountRepository
    {
        public async Task<UserAccount> AddAccount(UserAccount account)
        {
            var newAccount = await _appDbContext.UserAccounts.AddAsync(account);
            await SaveChangesAsync();
            return newAccount.Entity;
        }

        public async Task<bool> RemoveAccount(int id)
        {
            var accountToDelete = await _appDbContext.UserAccounts.FindAsync(id);
            if (accountToDelete == null)
                return false;
            _appDbContext.UserAccounts.Remove(accountToDelete);
            await SaveChangesAsync();
            return true;
        }

        public async Task<UserAccount> UpdateAccount(UserAccount account)
        {
            var updatedAccount = _appDbContext.UserAccounts.Update(account);
            await SaveChangesAsync();
            return updatedAccount.Entity;
        }
        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<UserAccount>> GetAllUserAccounts(int userId)
        {
            var userAccs = new List<UserAccount>();
            using (var context = _appDbContext)
            {
                userAccs = _appDbContext.UserAccounts.Where(acc => acc.UserId == userId).ToList();
            }
            if (userAccs.Count <= 0)
                return null;
            return userAccs;
        }

        public async Task<UserAccount> GetAccount(int id)
        {
            var account = _appDbContext.UserAccounts.FirstOrDefault(acc => acc.Id == id);
            if (account == null)
                return null;
            return account;
        }
    }
}
