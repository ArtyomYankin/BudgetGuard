using BG.Data.Entitites;
using BG.Data.Models;

namespace BG.Service.Transactions
{
    public interface ITransactionsService
    {
        Task<List<TransactionDto>> GetTransactionsByAccountAsync(int accountId);
        Task<TransactionDto> AddTransactionAsync(TransactionCreateDto transactionDto);
        Task<Transaction?> GetTransactionByIdAsync(int id);
    }
}
