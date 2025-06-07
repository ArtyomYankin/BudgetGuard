using BG.Data.Entitites;
using HomePlanner.Entitites;
using Microsoft.EntityFrameworkCore;

namespace BG.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "System",
                LastName = "User",
                Email = "system@budgetguard.com",
                PasswordHash = "precomputed-hash", 
                CreatedAt = new DateTime(2023, 1, 1), 
                Role = "Admin"
            }
        );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Еда",
                    Icon = "fa-utensils",
                    IsDefault = true,
                    UserId = 1 // Ссылка на системного пользователя
                },
                new Category
                {
                    Id = 2,
                    Name = "Транспорт",
                    Icon = "fa-car",
                    IsDefault = true,
                    UserId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Развлечения",
                    Icon = "fa-gamepad",
                    IsDefault = true,
                    UserId = 1
                }
            );

            // Уникальный Email пользователя
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Ограничение: сумма транзакции > 0
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            // Связи для Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Связь Budget -> BudgetCategory
            modelBuilder.Entity<Budget>()
                .HasMany(b => b.BudgetCategories)
                .WithOne(bc => bc.Budget)
                .HasForeignKey(bc => bc.BudgetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь BudgetCategory -> Category
            modelBuilder.Entity<BudgetCategory>()
                .HasOne(bc => bc.Category)
                .WithMany()
                .HasForeignKey(bc => bc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Связи для Account
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
