using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Catalog.ProductServices;
using DtoLayer.CatalogDto.ProductDetailDto;
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
        private readonly IProductDetailService _productDetailService;

        public ProductController(IProductService productService, ICategoryService categoryService, IProductDetailService productDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productDetailService = productDetailService;
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

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var values = await _productDetailService.ListProductDetailAsync(id);
            ViewBag.ProductID = id;
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDetail(string id)
        {
            var values = await _productService.GetProductAsync(id);
            var productDetailViewModel = new ProductDetailViewModel
            {
                GetProductDto = values,
            };
            return View(productDetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }
    }
}
