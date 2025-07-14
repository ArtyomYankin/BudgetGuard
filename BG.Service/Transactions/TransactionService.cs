using BG.Data.Entitites;
using BG.Data.Models;
using BG.Repository.Transactions;
using BG.Service.Account;

namespace BG.Service.Transactions
{
    public class TransactionService(ITransactionsRepository _transactionsRepository, IAccountService _accountService) : ITransactionsService
    {
        public async Task<TransactionDto> AddTransactionAsync(TransactionCreateDto transactionDto)
        {
            var transaction = new Transaction
            {
                Amount = transactionDto.Amount,
                Type = transactionDto.Type,
                Description = transactionDto.Description,
                Date = transactionDto.Date,
                CategoryId = transactionDto.CategoryId,
                UserAccountId = transactionDto.AccountId,
                Tag = ""
            };

            if (transaction.CategoryId == 0)
            {
                //TODO: AI auto categorising
                //transaction.Category = await _aiService.PredictCategoryAsync(dto.Description);
            }

            var newTransaction = await _transactionsRepository.AddAsync(transaction);
            var account = await _accountService.GetUserAcc(transaction.UserAccountId);
            if (newTransaction.Type == TransactionType.Income)
                account.Balance += newTransaction.Amount;
            else
                account.Balance -= newTransaction.Amount;

            await _accountService.UpdateUserAccount(account);

            return new TransactionDto()
            {
                Id = newTransaction.Id,
                Amount = newTransaction.Amount,
                Description = newTransaction.Description,
                Date = newTransaction.Date,
                UserAccountId = newTransaction.UserAccountId,
                TransactionType = transaction.Type,
                CategoryId = 1 // transaction.Category.Id,
            };
        }

        public async Task<List<TransactionDto>> GetTransactionsByAccountAsync(int accountId)
        {
            var transcations = await _transactionsRepository.GetByAccountAsync(accountId);
            if (transcations == null)
                return new List<TransactionDto>();
            return ToAccountDtoList(transcations);
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await _transactionsRepository.GetByIdAsync(id);
        }

        public List<TransactionDto> ToAccountDtoList(List<Transaction> transactions)
        {
            return transactions.Select(transaction => new TransactionDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                CategoryId = transaction.Category.Id,
                TransactionType = transaction.Type,
                Description = transaction.Description,
                Date = transaction.Date,
                UserAccountId = transaction.UserAccountId,
            }).ToList();
        }
    }
}
