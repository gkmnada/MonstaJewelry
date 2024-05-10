using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Catalog.ProductImageService;
using BusinessLayer.Catalog.ProductServices;
using BusinessLayer.Comment.CommentServices;
using DtoLayer.CatalogDto.ProductDetailDto;
using DtoLayer.CatalogDto.ProductDto;
using DtoLayer.CatalogDto.ProductImageDto;
using DtoLayer.CommentDto.UserCommentDto;
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
        private readonly IProductImageService _productImageService;
        private readonly ICommentService _commentService;

        public ProductController(IProductService productService, ICategoryService categoryService, IProductDetailService productDetailService, IProductImageService productImageService, ICommentService commentService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
            _commentService = commentService;
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

        [HttpGet]
        public async Task<IActionResult> UpdateDetail(string id)
        {
            var values = await _productDetailService.GetProductDetailAsync(id);
            var productDetailViewModel = new ProductDetailViewModel
            {
                GetProductDetailDto = values,
            };
            return View(productDetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> ProductImage(string id)
        {
            var values = await _productImageService.ListProductImageAsync(id);
            ViewBag.ProductID = id;
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateImage(string id)
        {
            var values = await _productService.GetProductAsync(id);
            var productImageViewModel = new ProductImageViewModel
            {
                GetProductDto = values,
            };
            return View(productImageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateImage(string id)
        {
            var values = await _productImageService.GetProductImageAsync(id);
            var productImageViewModel = new ProductImageViewModel
            {
                GetProductImageDto = values,
            };
            return View(productImageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> ProductComment(string id)
        {
            var values = await _commentService.ListCommentAsync(id);
            ViewBag.ProductID = id;
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateComment(string id)
        {
            var values = await _productService.GetProductAsync(id);
            var commentViewModel = new CommentViewModel
            {
                GetProductDto = values,
            };
            return View(commentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CommentDate = DateTime.Now;
            createCommentDto.Status = true;

            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }
    }
}