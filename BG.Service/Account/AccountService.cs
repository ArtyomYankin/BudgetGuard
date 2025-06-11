using BG.Data.Entitites;
using BG.Data.Models;
using BG.Repository.Acc;
using HP.Service;

namespace BG.Service.Account
{
    public class AccountService(IAccountRepository _accountRepository, IAuthService _authService) : IAccountService
    {
        public async Task<AccountDto?> CreateUserAccount(AccountCreateDto userAccountDto)
        {
            var userAccount = new UserAccount()
            {
                Name = userAccountDto.Name,
                Balance = userAccountDto.CurrentBalance,
                Currency = userAccountDto.Currency,
                IsActive = true,
                UserId = userAccountDto.UserId,
            };
            var account = await _accountRepository.AddAccount(userAccount);
            if (account == null)
                return null;

            return new AccountDto()
            {
                Id = account.Id,
                Name = account.Name,
                Currency = account.Currency,
                CurrentBalance = account.Balance,
            };
        }

        public async Task DeleteAccount(int accountId)
        {
            await _accountRepository.RemoveAccount(accountId);
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

        public async Task<AccountDto> UpdateUserAccount(AccountDto accountDto)
        {
            var userAccount = new UserAccount()
            {
                Name = accountDto.Name,
                Balance = accountDto.CurrentBalance,
                Currency = accountDto.Currency,
                Id = accountDto.Id,
            };
            var updatedAccount = await _accountRepository.UpdateAccount(userAccount);

            return new AccountDto()
            {
                Id = updatedAccount.Id,
                Name = updatedAccount.Name,
                Currency = updatedAccount.Currency,
                CurrentBalance = updatedAccount.Balance,
            };
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
