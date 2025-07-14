using BG.Data.Models;
using BG.Service.Categories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            if (categories == null || !categories.Any())
                return NotFound("No categories");

            return Ok(categories);
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(AccountDto), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryDto dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var accountResponse = await _categoryService.CreateCategory(dto);
        //}
    }
}
