using BG.Data.Entitites;
using BG.Data.Models;

namespace BG.Service.Account
{
    public interface IAccountService
    {
        Task<AccountDto> GetUserAccount(int id);
        Task<AccountDto?> CreateUserAccount(AccountCreateDto userAccount);
        Task<AccountDto> UpdateUserAccount(AccountUpdateDto accountDto);
        Task<UserAccount> UpdateUserAccount(UserAccount account);
        Task<bool> DeleteAccount(int accountDId);
        Task<List<AccountDto>> GetAllAccountsForUser(int userId);
        Task<UserAccount> GetUserAcc(int id);
    }
}
