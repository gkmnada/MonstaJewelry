using BusinessLayer.Catalog.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var values = await _productService.ListProductByCategoryAsync(id);
            ViewBag.CategoryName = values.FirstOrDefault()?.Category.CategoryName;
            return View(values);
        }
    }
}
