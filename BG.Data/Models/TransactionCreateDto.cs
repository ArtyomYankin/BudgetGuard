using BG.Data.Entitites;
using System.ComponentModel.DataAnnotations;

namespace BG.Data.Models
{
    public class TransactionCreateDto
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType Type { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int? CategoryId { get; set; }

        [Required]
        public int AccountId { get; set; }
    }
}
