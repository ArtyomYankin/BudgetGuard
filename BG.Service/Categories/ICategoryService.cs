using BG.Data.Models;

namespace BG.Service.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<CategoryDto> CreateCategory(CategoryDto category);
    }
}
