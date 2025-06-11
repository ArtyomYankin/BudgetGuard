using BG.Data.Models;

namespace BG.Service.Account
{
    public interface IAccountService
    {
        Task<AccountDto?> CreateUserAccount(AccountCreateDto userAccount);
        Task<AccountDto> UpdateUserAccount(AccountDto accountDto);
        Task DeleteAccount(int accountDId);
        Task<List<AccountDto>> GetAllAccountsForUser(int userId);
    }
}
