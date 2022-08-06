using JShop.ProductApi.Dtos;
using JShop.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetCategories()
        {
            var categoriesDto = await _productService.GetProducts();
            if (categoriesDto is null)

                //404 not found
                return NotFound("Categories not found");

            //200OK
            return Ok(categoriesDto);
        }

        // passando parametro e definindo nome
        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetById(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto is null)

                //404 not found
                return NotFound("Categories not found");

            //200OK
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductDto productDto)
        {
            if (productDto is null) { return BadRequest("Invalid Data"); }

            await _productService.CreateProduct(productDto);

            //201 created
            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id },
                productDto);
        }

        // tipo parâmetro
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id) { return BadRequest(); }

            if (productDto is null) { return BadRequest(); }

            await _productService.UpdateProduct(productDto);

            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto is null)
            {
                return NotFound("Product not found");
            }

            await _productService.DeleteProduct(id);

            return Ok(productDto);
        }
    }
}



