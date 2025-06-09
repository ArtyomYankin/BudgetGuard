using HomePlanner.Entitites;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BG.Data.Entitites
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Limit { get; set; }
        public BudgetPeriod Period { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

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
