using HomePlanner.Entitites;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BG.Data.Entitites
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Icon { get; set; }
        public bool IsDefault { get; set; } = false;

        public int? UserId { get; set; }
        public User? User { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
