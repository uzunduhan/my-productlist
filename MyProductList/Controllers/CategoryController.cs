using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProductList.Dto.Dtos;
using MyProductList.Service.Abstract;

namespace MyProductList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var category =  await _categoryService.GetCategoryById(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddDirector([FromBody] CategoryDto newCategory)
        {
            //DirectorDtoValidator validator = new DirectorDtoValidator();

            //validator.ValidateAndThrow(newDirector);


            //await _genreService.isMovieExistByTitle(newMovie.Title);

            await _categoryService.AddCategoryAsync(newCategory);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromQuery] int id, [FromBody] CategoryDto updatedCategory)
        {
            //DirectorDtoValidator validator = new DirectorDtoValidator();
            //validator.ValidateAndThrow(updatedDirector);

            await _categoryService.UpdateCategoryAsync(id, updatedCategory);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            await _categoryService.SafeDeleteCategorytAsync(id);

            return NoContent();
        }
    }
}
