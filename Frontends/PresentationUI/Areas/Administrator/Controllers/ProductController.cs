using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Catalog.ProductImageService;
using BusinessLayer.Catalog.ProductServices;
using DtoLayer.CatalogDto.ProductDetailDto;
using DtoLayer.CatalogDto.ProductDto;
using DtoLayer.CatalogDto.ProductImageDto;
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
        private readonly IProductImageService _productImageService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService, IProductDetailService productDetailService, IProductImageService productImageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
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
        public async Task<IActionResult> CreateProduct(IFormFile CoverImage, List<IFormFile> Images, CreateProductWithDetailDto createProductWithDetailDto)
        {
            if (CoverImage != null && CoverImage.Length > 0)
            {
                var fileName = Path.GetFileName(CoverImage.FileName);
                var fullPath = Path.Combine("wwwroot/images/products/" + fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await CoverImage.CopyToAsync(stream);
                }
                createProductWithDetailDto.ProductImage = "/images/products/" + fileName;

                for (int i = 0; i < Images.Count; i++)
                {
                    if (Images[i] != null && Images[i].Length > 0)
                    {
                        var imageName = Path.GetFileName(Images[i].FileName);
                        var imagePath = Path.Combine("wwwroot/images/products/", imageName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await Images[i].CopyToAsync(stream);
                        }
                        var relativePath = "/images/products/" + imageName;

                        switch (i)
                        {
                            case 0:
                                createProductWithDetailDto.Image1 = relativePath;
                                break;
                            case 1:
                                createProductWithDetailDto.Image2 = relativePath;
                                break;
                            case 2:
                                createProductWithDetailDto.Image3 = relativePath;
                                break;
                        }
                    }
                }
                await _productService.CreateProductAsync(createProductWithDetailDto);
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
            var details = await _productDetailService.GetProductDetailWithProductAsync(id);
            var images = await _productImageService.GetProductImageWithProductAsync(id);

            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();
            ViewBag.Category = categories;
            ViewBag.SelectedCategory = product.CategoryID;

            var productViewModel = new ProductViewModel
            {
                GetProductDto = product,
                GetProductDetailDto = details,
                GetProductImageDto = images
            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(IFormFile CoverImage, List<IFormFile> Images, UpdateProductDto updateProductDto, UpdateProductDetailDto updateProductDetailDto, UpdateProductImageDto updateProductImageDto)
        {
            if (CoverImage != null && CoverImage.Length > 0)
            {
                var fileName = Path.GetFileName(CoverImage.FileName);
                var fullPath = Path.Combine("wwwroot/images/products/", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await CoverImage.CopyToAsync(stream);
                }
                updateProductDto.ProductImage = "/images/products/" + fileName;
            }
            else
            {
                var existingProduct = await _productService.GetProductAsync(updateProductDto.ProductID);
                updateProductDto.ProductImage = existingProduct.ProductImage;
            }

            for (int i = 0; i < Images.Count; i++)
            {
                if (Images[i] != null && Images[i].Length > 0)
                {
                    var imageName = Path.GetFileName(Images[i].FileName);
                    var imagePath = Path.Combine("wwwroot/images/products/", imageName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await Images[i].CopyToAsync(stream);
                    }
                    var relativePath = "/images/products/" + imageName;

                    switch (i)
                    {
                        case 0:
                            updateProductImageDto.Image1 = relativePath;
                            break;
                        case 1:
                            updateProductImageDto.Image2 = relativePath;
                            break;
                        case 2:
                            updateProductImageDto.Image3 = relativePath;
                            break;
                    }
                }
                else
                {
                    var existingProduct = await _productImageService.GetProductImageWithProductAsync(updateProductImageDto.ProductID);
                    switch (i)
                    {
                        case 0:
                            updateProductImageDto.Image1 = existingProduct.Image1;
                            break;
                        case 1:
                            updateProductImageDto.Image2 = existingProduct.Image2;
                            break;
                        case 2:
                            updateProductImageDto.Image3 = existingProduct.Image3;
                            break;
                    }
                }
            }
            await _productService.UpdateProductAsync(updateProductDto);
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return RedirectToAction("Index", "Product", new { area = "Administrator" });
        }
    }
}
