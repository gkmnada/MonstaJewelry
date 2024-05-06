using CatalogAPI.Dtos.ProductImageDto;
using CatalogAPI.Services.ProductImageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProductImage(string id)
        {
            var values = await _productImageService.ListProductImageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetProductImage")]
        public async Task<IActionResult> GetProductImage(string id)
        {
            var value = await _productImageService.GetProductImageAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Başarılı");
        }

        [HttpGet("GetProductImageWithProduct")]
        public async Task<IActionResult> GetProductImageWithProduct(string id)
        {
            var value = await _productImageService.GetProductImageWithProductAsync(id);
            return Ok(value);
        }
    }
}
