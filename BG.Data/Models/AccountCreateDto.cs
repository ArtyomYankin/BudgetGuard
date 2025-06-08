using BG.Data.Entitites;
using System.ComponentModel.DataAnnotations;

namespace BG.Data.Models
{
    public class AccountCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Range(0, double.MaxValue)]
        public decimal InitialBalance { get; set; } = 0;
    }
}
