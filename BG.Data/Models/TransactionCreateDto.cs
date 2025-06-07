using System.ComponentModel.DataAnnotations;

namespace BG.Data.Models
{
    public class TransactionCreateDto
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        public int CategoryId { get; set; }

        [Required]
        public int AccountId { get; set; }
    }
}
