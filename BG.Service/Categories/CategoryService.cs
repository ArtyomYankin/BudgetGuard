using BG.Data.Entitites;
using BG.Data.Models;
using BG.Repository;

namespace BG.Service.Categories
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public async Task<CategoryDto> CreateCategory(CategoryDto category)
        {
            var newCategory = new Category() { Name = category.Name };
            var categoryResponse = _categoryRepository.AddCategory(newCategory);
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategories().Result;
            var cat = ToCategoryDtoList(categories);
            return cat;
        }
        public List<CategoryDto> ToCategoryDtoList(List<Category> categories)
        {
            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            }).ToList();
        }
    }
}
