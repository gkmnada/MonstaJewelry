using CatalogAPI.Dtos.ProductDetailDto;
using CatalogAPI.Services.ProductDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ListProductDetail()
        {
            var values = await _productDetailService.ListProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("GetProductDetail")]
        public async Task<IActionResult> GetProductDetail(string id)
        {
            var values = await _productDetailService.GetProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Başarılı");
        }

        [HttpGet("GetProductDetailWithProduct")]
        public async Task<IActionResult> GetProductDetailWithProduct(string id)
        {
            var values = await _productDetailService.GetProductDetailWithProductAsync(id);
            return Ok(values);
        }
    }
}
