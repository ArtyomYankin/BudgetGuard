using BG.Data.Entitites;

namespace BG.Data.Models
{
    public class AccountUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public Currency Currency { get; set; }
    }
}
