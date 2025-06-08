using BG.Data.Entitites;

namespace BG.Data.Models
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public CategoryDto? Category { get; set; }
        public int UserAccountId { get; set; }

    }
}
