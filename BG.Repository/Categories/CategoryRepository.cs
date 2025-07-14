using BG.Data;
using BG.Data.Entitites;
using Microsoft.EntityFrameworkCore;

namespace BG.Repository
{
    public class CategoryRepository(AppDbContext _appDbContext) : ICategoryRepository
    {
        public async Task<Category> AddCategory(Category category)
        {
            var newCategory = await _appDbContext.Categories.AddAsync(category);
            _appDbContext.SaveChanges();
            return newCategory.Entity;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var allCategories = await _appDbContext.Categories.ToListAsync();
            return allCategories;
        }
    }
}
