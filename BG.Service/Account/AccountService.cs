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
            var user = _authService.GetUserById(userAccountDto.UserId);
            if (user == null)
                return null;
            var userAccount = new UserAccount()
            {
                Name = userAccountDto.Name,
                Balance = userAccountDto.InitialBalance,
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

        public async Task<bool> DeleteAccount(int accountId)
        {
            return await _accountRepository.RemoveAccount(accountId);
        }

        public async Task<List<AccountDto>> GetAllAccountsForUser(int userId)
        {
            var user = _authService.GetUserById(userId);
            if (user == null)
                return null;
            var userAccounts = await _accountRepository.GetAllUserAccounts(userId);
            if (userAccounts == null)
                return new List<AccountDto>();
            var userAccountsDto = ToAccountDtoList(userAccounts);
            return userAccountsDto;
        }

        public async Task<AccountDto> UpdateUserAccount(AccountUpdateDto accountDto)
        {
            var account = _accountRepository.GetAccount(accountDto.Id).Result;
            account.Name = accountDto.Name;
            account.Balance = accountDto.CurrentBalance;
            account.Currency = accountDto.Currency;
            account.IsActive = accountDto.IsActive;

            var updatedAccount = await _accountRepository.UpdateAccount(account);

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

        public async Task<AccountDto> GetUserAccount(int id)
        {
            var account = await _accountRepository.GetAccount(id);
            if (account == null)
                return null;

            return new AccountDto()
            {
                Id = account.Id,
                Name = account.Name,
                Currency = account.Currency,
                CurrentBalance = account.Balance,
                IsActive = account.IsActive,
            };
        }

        public async Task<UserAccount> GetUserAcc(int id)
        {
            var account = await _accountRepository.GetAccount(id);
            if (account == null)
                return null;

            return account;
        }

        public async Task<UserAccount> UpdateUserAccount(UserAccount account)
        {
            var updatedFccount = await _accountRepository.UpdateAccount(account);
            return account;
        }
    }
}
