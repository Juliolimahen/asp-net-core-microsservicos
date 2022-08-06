using JShop.ProductApi.Dtos;
using JShop.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JShop.ProductApi.Controllers
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
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categoriesDto = await _categoryService.GetCategories();
            if (categoriesDto is null)

                //404 not found
                return NotFound("Categories not found");

            //200OK
            return Ok(categoriesDto);
        }

        //Definindo rota
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriasProducts()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();
            if (categoriesDto is null)

                //404 not found
                return NotFound("Categories not found");

            //200OK
            return Ok(categoriesDto);
        }

        // passando parametro e definindo nome
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetById(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto is null)

                //404 not found
                return NotFound("Categories not found");

            //200OK
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto is null) { return BadRequest("Invalid Data"); }

            await _categoryService.CreateCategory(categoryDto);

            //201 created
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId },
                categoryDto);
        }

        // tipo parâmetro
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryDto categoryDto)
        {
            if (id != categoryDto.CategoryId) { return BadRequest(); }

            if (categoryDto is null) { return BadRequest(); }

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto is null)
            {
                return NotFound("Category not found");
            }

            await _categoryService.DeleteCategory(id);

            return Ok(categoryDto);
        }
    }
}



