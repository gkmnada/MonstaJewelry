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
        private readonly IProductDetailService _productDetailService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService, IProductDetailService productDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productDetailService = productDetailService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.ListProductWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var values = await _categoryService.ListCategoryAsync();

            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();
            ViewBag.Category = categories;
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
                var relativePath = Path.Combine("/images/products/" + fileName);
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

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var product = await _productService.GetProductAsync(id);
            var values = await _categoryService.ListCategoryAsync();

            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();
            ViewBag.Category = categories;
            ViewBag.SelectedCategory = product.CategoryID;
            ViewBag.ProductImage = product.ProductImage;

            var productViewModel = new ProductViewModel
            {
                GetProductDto = product
            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(IFormFile file, UpdateProductDto updateProductDto)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fullPath = Path.Combine("wwwroot/images/products/" + fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var relativePath = Path.Combine("/images/products/" + fileName);
                updateProductDto.ProductImage = relativePath;
            }
            else
            {
                var existingProduct = await _productService.GetProductAsync(updateProductDto.ProductID);
                updateProductDto.ProductImage = existingProduct.ProductImage;
            }
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetail(string id)
        {
            return View();
        }
    }
}
