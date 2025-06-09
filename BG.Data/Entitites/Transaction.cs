using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BG.Data.Entitites
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public TransactionType Type { get; set; }

        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public string Tag { get; set; }
    }
    public enum TransactionType
    {
        Income,
        Expense
    }
}
