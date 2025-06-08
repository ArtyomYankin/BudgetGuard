using BG.Data.Entitites;
using BG.Data.Models;
using BG.Repository.Acc;
using HP.Service;

namespace BG.Service.Account
{
    public class AccountService(IAccountRepository _accountRepository, IAuthService _authService) : IAccountService
    {
        public Task<AccountDto> CreateUserAccount(AccountCreateDto userAccountDto)
        {
            var userAccount = new UserAccount()
            {
                Name = userAccountDto.Name,
                Balance = userAccountDto.InitialBalance,
                Currency = userAccountDto.Currency,
            };
            return null;
        }

        public Task DeleteAccount(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AccountDto>> GetAllAccountsForUser(int userId)
        {
            var user = _authService.GetUserById(userId);
            if (user == null)
                return null;
            var userAccounts = await _accountRepository.GetAllUserAccounts(userId);
            var userAccountsDto = ToAccountDtoList(userAccounts);
            return userAccountsDto;
        }

        public Task<AccountDto> UpdateUserAccount(AccountDto accountDto)
        {
            throw new NotImplementedException();
        }

        public List<AccountDto> ToAccountDtoList(List<UserAccount> accounts)
        {
            return accounts.Select(account => new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                Currency = account.Currency,
                CurrentBalance = account.Balance
            }).ToList();
        }
    }
}
