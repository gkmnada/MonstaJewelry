using CatalogAPI.Dtos.ProductDto;
using CatalogAPI.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> ListProduct()
        {
            var values = await _productService.ListProductAsync();
            return Ok(values);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var values = await _productService.GetProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Başarılı");
        }

        [HttpGet("ListProductWithCategory")]
        public async Task<IActionResult> ListProductWithCategory()
        {
            var values = await _productService.ListProductWithCategoryAsync();
            return Ok(values);
        }
    }
}
