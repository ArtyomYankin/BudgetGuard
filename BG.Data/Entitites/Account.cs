using HomePlanner.Entitites;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BG.Data.Entitites
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public bool IsActive { get; set; } = true;

        public int UserId { get; set; }
        public User? User { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Transaction> Transactions { get; set; }
    }
    public enum Currency
    {
        USD = 0,
        BLR = 1,
        EUR = 2,
    }
}
