using BG.Data.Entitites;
using BG.Data.Models;
using BG.Repository.Transactions;

namespace BG.Service.Transactions
{
    public class TransactionService(ITransactionsRepository _transactionsRepository) : ITransactionsService
    {
        public async Task<TransactionDto> AddTransactionAsync(TransactionCreateDto transactionDto)
        {
            var transaction = new Transaction
            {
                Amount = transactionDto.Amount,
                Description = transactionDto.Description,
                Date = transactionDto.Date,
                AccountId = transactionDto.AccountId
            };

            if (transaction.CategoryId == 0)
            {
                //TODO: AI auto categorising
                //transaction.Category = await _aiService.PredictCategoryAsync(dto.Description);
            }

            var newTransaction = await _transactionsRepository.AddAsync(transaction);
            return new TransactionDto()
            {
                Id = newTransaction.Id,
                Amount = newTransaction.Amount,
                Description = newTransaction.Description,
                Date = newTransaction.Date,
                AccountId = newTransaction.AccountId,
            };
        }

        public async Task<List<Transaction>> GetTransactionByAccountAsync(int accountId)
        {
            return await _transactionsRepository.GetByAccountAsync(accountId);
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await _transactionsRepository.GetByIdAsync(id);
        }
    }
}
