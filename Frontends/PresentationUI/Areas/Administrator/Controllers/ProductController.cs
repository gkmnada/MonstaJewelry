using BusinessLayer.Catalog.ProductServices;
using DtoLayer.CatalogDto.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.ListProductWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(IFormFile file, CreateProductDto createProductDto)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fullPath = Path.Combine("wwwroot/images/products/" + fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var relativePath = Path.Combine("/images/products", fileName);
                createProductDto.ProductImage = relativePath;

                await _productService.CreateProductAsync(createProductDto);
                return RedirectToAction("Index", "Product", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }
    }
}
