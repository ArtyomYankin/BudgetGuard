using BG.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Repository.Transactions
{
    public interface ITransactionsRepository
    {
        // Основные методы
        Task<Transaction?> GetByIdAsync(int id);
        Task<List<Transaction>> GetByAccountAsync(int accountId);
        Task AddAsync(Transaction transaction);

        // Специфичные методы для BudgetGuard
        // Task<Dictionary<string, decimal>> GetSpendingByCategoryAsync(int accountId);
        //Task<List<Transaction>> GetByPeriodAsync(int accountId, DateTime start, DateTime end);
        //Task CategorizeAutomaticallyAsync(Transaction transaction); // AI-категоризация
    }
}
