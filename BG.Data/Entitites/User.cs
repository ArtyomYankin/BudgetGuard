using BG.Data.Entitites;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HomePlanner.Entitites
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Role { get; set; } = "User";
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }

        // Навигационные свойства
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<UserAccount> UserAccounts { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Category> Categories { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Budget> Budgets { get; set; }
    }
}
