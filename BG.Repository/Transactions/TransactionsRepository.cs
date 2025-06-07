using BG.Data;
using BG.Data.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Repository.Transactions
{
    public class TransactionsRepository(AppDbContext _context) : ITransactionsRepository
    {
       // private readonly IAIClient _aiClient;

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        // Получить траты по категориям для конкретного аккаунта
        //public async Task<Dictionary<Category, decimal>> GetSpendingByCategoryAsync(int accountId)
        //{
        //    return await _context.Transactions
        //        .Where(t => t.AccountId == accountId && t.Amount < 0)
        //        .GroupBy(t => t.Category)
        //        .Select(g => new
        //        {
        //            Category = g.Key,
        //            Total = g.Sum(t => t.Amount)
        //        })
        //        .ToDictionaryAsync(x => x.Category, x => Math.Abs(x.Total));
        //}

        // Автоматическая категоризация через AI
        //public async Task CategorizeAutomaticallyAsync(Transaction transaction)
        //{
        //    if (string.IsNullOrEmpty(transaction.Category))
        //    {
        //        transaction.Category = await _aiClient.PredictCategoryAsync(
        //            transaction.Description,
        //            transaction.Amount
        //        );
        //    }
        //}

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return _context.Transactions.FirstOrDefault(tran => tran.Id == id);
        }

        public async Task<List<Transaction>> GetByAccountAsync(int accountId)
        {
            return _context.Transactions.Where(tran => tran.AccountId == accountId).ToList();

        }

        public Task<List<Transaction>> GetByPeriodAsync(int accountId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
