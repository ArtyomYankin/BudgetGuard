using BG.Data.Entitites;

namespace BG.Repository.Transactions
{
    public interface ITransactionsRepository
    {
        Task<Transaction?> GetByIdAsync(int id);
        Task<List<Transaction>> GetByAccountAsync(int accountId);
        Task<Transaction> AddAsync(Transaction transaction);

        //Task<Dictionary<string, decimal>> GetSpendingByCategoryAsync(int accountId);
        //Task<List<Transaction>> GetByPeriodAsync(int accountId, DateTime start, DateTime end);
        //Task CategorizeAutomaticallyAsync(Transaction transaction); // AI-категоризация
    }
}
