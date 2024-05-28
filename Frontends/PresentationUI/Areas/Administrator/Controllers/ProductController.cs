using BusinessLayer.Catalog.ProductServices;
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
    }
}
