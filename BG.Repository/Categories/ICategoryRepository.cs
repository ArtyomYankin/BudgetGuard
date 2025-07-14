using BG.Data.Entitites;

namespace BG.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<List<Category>> GetAllCategories();
    }
}
