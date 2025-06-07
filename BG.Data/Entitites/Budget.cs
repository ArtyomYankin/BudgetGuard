using HomePlanner.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BG.Data.Entitites
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Limit { get; set; } // Лимит на период
        public BudgetPeriod Period { get; set; } // Месяц/Неделя/Год
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Внешний ключ
        public int UserId { get; set; }
        public User User { get; set; }

        // Навигационные свойства
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<BudgetCategory> BudgetCategories { get; set; }
    }
    public enum BudgetPeriod
    {
        Weekly,
        Monthly,
        Yearly
    }
}
