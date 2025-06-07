using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BG.Data.Entitites
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public TransactionType Type { get; set; } // Доход/Расход

        // Внешние ключи
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Метка (например, "Продукты", "Кафе")
        public string Tag { get; set; }
    }
    public enum TransactionType
    {
        Income,    // Доход
        Expense    // Расход
    }
}
