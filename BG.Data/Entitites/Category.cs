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
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Icon { get; set; } // Иконка (FontAwesome)
        public bool IsDefault { get; set; } = false; // Системная категория

        // Внешний ключ
        public int? UserId { get; set; }
        public User? User { get; set; }

        // Навигационные свойства
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
