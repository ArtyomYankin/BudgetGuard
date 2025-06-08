using BG.Data.Entitites;
namespace BG.Repository.Acc
{
    public interface IAccountRepository
    {
        Task<UserAccount> AddAccount(UserAccount account);
        Task<UserAccount> UpdateAccount(UserAccount account);
        Task RemoveAccount(int id);
        Task<List<UserAccount>> GetAllUserAccounts(int userId);
    }
}
