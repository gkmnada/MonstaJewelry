using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.ProductServices;
using DtoLayer.CatalogDto.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _productService.ListProductWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var values = await _categoryService.ListCategoryAsync();
            List<SelectListItem> listCategory = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID
                                                 }).ToList();
            ViewBag.CategoryList = listCategory;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _categoryService.ListCategoryAsync();
            List<SelectListItem> listCategory = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID
                                                 }).ToList();
            ViewBag.CategoryList = listCategory;

            var product = await _productService.GetProductAsync(id);
            var productViewModel = new ProductViewModel
            {
                GetProductDto = product,
            };
            ViewBag.SelectedCategory = product.CategoryID;

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(updateProductDto);
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
