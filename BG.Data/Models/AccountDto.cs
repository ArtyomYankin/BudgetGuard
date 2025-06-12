using BG.Data.Entitites;

namespace BG.Data.Models
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
    }
}
