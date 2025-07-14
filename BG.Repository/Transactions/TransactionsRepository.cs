using BG.Data;
using BG.Data.Entitites;
using Microsoft.EntityFrameworkCore;

namespace BG.Repository.Transactions
{
    public class TransactionsRepository(AppDbContext _context) : ITransactionsRepository
    {

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            var createdTransaction = await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return createdTransaction.Entity;
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(tran => tran.Id == id);

            if (transaction == null)
                return null;

            return transaction;
        }

        public async Task<List<Transaction>?> GetByAccountAsync(int accountId)
        {
            var transactions = await _context.Transactions.Where(tran => tran.UserAccountId == accountId).OrderByDescending(t => t.Date)
            .Include(t => t.Category)
            .ToListAsync();
            if (transactions.Count > 0)
                return transactions;
            return null;
        }

        public Task<List<Transaction>> GetByPeriodAsync(int accountId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
