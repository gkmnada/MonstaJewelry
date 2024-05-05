using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Catalog.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductDetailService _productDetailService;

        public ProductController(IProductService productService, ICategoryService categoryService, IProductDetailService productDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var values = await _productService.ListProductByCategoryAsync(id);
            var category = await _categoryService.GetCategoryAsync(id);
            ViewBag.CategoryName = category.CategoryName;
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(string id)
        {
            var values = await _productDetailService.GetProductDetailWithProductAsync(id);
            string categoryID = values.Product.CategoryID;
            var categoryName = await _categoryService.GetCategoryAsync(categoryID);
            ViewBag.CategoryID = categoryID;
            ViewBag.CategoryName = categoryName.CategoryName;
            ViewBag.ProductName = values.Product.ProductName;
            return View(values);
        }
    }
}
