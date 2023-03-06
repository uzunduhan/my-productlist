using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProductList.Dto.Dtos;
using MyProductList.Service.Abstract;

namespace MyProductList.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var product =  await _productService.GetSingleProductByIdAsync(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto newProduct)
        {
            //MovieDtoValidator validator = new MovieDtoValidator();

            //validator.ValidateAndThrow(newMovie);
            //ValidationResult result = validator.Validate(newMovie);

            //if(!result.IsValid) 
            //{
            //    foreach (var error in result.Errors)
            //    {
            //             throw new InvalidOperationException(error.ErrorMessage);
            //    }
            //}

           // await _productService.isMovieExistByTitle(newMovie.Title);

            await _productService.AddProductAsync(newProduct);

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromQuery] int id, [FromBody] ProductDto updatedProduct)
        {
            //MovieDtoValidator validator = new MovieDtoValidator();
            //validator.ValidateAndThrow(updatedMovie);

            await _productService.UpdateProductAsync(id, updatedProduct);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] int id)
        {
            await _productService.DeleteProductAsync(id);

            return NoContent();
        }


    }
}