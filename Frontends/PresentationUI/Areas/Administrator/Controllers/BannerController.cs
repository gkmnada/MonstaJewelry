using BusinessLayer.Catalog.BannerServices;
using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.ProductServices;
using BusinessLayer.Discount.DiscountServices;
using DtoLayer.CatalogDto.BannerDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IDiscountService _discountService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public BannerController(IBannerService bannerService, IDiscountService discountService, IProductService productService, ICategoryService categoryService)
        {
            _bannerService = bannerService;
            _discountService = discountService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bannerService.ListBannerWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBanner()
        {
            var discounts = await _discountService.ListCouponAsync();
            var products = await _productService.ListProductAsync();
            var categories = await _categoryService.ListCategoryAsync();

            List<SelectListItem> listDiscount = (from x in discounts
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Code,
                                                     Value = x.Code
                                                 }).ToList();
            ViewBag.Discount = listDiscount;

            List<SelectListItem> listProduct = (from x in products
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductID
                                                }).ToList();
            ViewBag.Product = listProduct;

            List<SelectListItem> listCategory = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID
                                                 }).ToList();
            ViewBag.Category = listCategory;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(IFormFile CoverImage, CreateBannerDto createBannerDto)
        {
            if (CoverImage != null && CoverImage.Length > 0)
            {
                var fileName = Path.GetFileName(CoverImage.FileName);
                var filePath = Path.Combine("wwwroot/images/banner/" + fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await CoverImage.CopyToAsync(stream);
                }
                createBannerDto.ProductImage = "/images/banner/" + fileName;

                var values = await _productService.GetProductAsync(createBannerDto.ProductID);
                var coupon = await _discountService.GetCouponCodeAsync(createBannerDto.CouponCode);

                var discountPrice = values.ProductPrice - values.ProductPrice / 100 * coupon.Rate;
                discountPrice = Math.Ceiling(discountPrice);

                createBannerDto.ProductName = values.ProductName;
                createBannerDto.ProductPrice = decimal.Parse(discountPrice.ToString("F2"));

                await _bannerService.CreateBannerAsync(createBannerDto);
                return RedirectToAction("Index", "Banner", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteBanner(string id)
        {
            await _bannerService.DeleteBannerAsync(id);
            return RedirectToAction("Index", "Banner", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(string id)
        {
            var discounts = await _discountService.ListCouponAsync();
            var products = await _productService.ListProductAsync();
            var categories = await _categoryService.ListCategoryAsync();

            List<SelectListItem> listDiscount = (from x in discounts
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Code,
                                                     Value = x.Code
                                                 }).ToList();
            ViewBag.Discount = listDiscount;

            List<SelectListItem> listProduct = (from x in products
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductID
                                                }).ToList();
            ViewBag.Product = listProduct;

            List<SelectListItem> listCategory = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID
                                                 }).ToList();
            ViewBag.Category = listCategory;

            var values = await _bannerService.GetBannerAsync(id);

            ViewBag.SelectedCode = values.CouponCode;
            ViewBag.SelectedCategory = values.CategoryID;
            ViewBag.SelectedProduct = values.ProductID;

            var bannerViewModel = new BannerViewModel
            {
                GetBannerDto = values
            };
            return View(bannerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(IFormFile CoverImage, UpdateBannerDto updateBannerDto)
        {
            if (CoverImage != null && CoverImage.Length > 0)
            {
                var fileName = Path.GetFileName(CoverImage.FileName);
                var filePath = Path.Combine("wwwroot/images/banner/" + fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await CoverImage.CopyToAsync(stream);
                }
                updateBannerDto.ProductImage = "/images/banner/" + fileName;
            }
            else
            {
                var existingImage = await _bannerService.GetBannerAsync(updateBannerDto.BannerID);
                updateBannerDto.ProductImage = existingImage.ProductImage;
            }
            var values = await _productService.GetProductAsync(updateBannerDto.ProductID);
            var coupon = await _discountService.GetCouponCodeAsync(updateBannerDto.CouponCode);

            var discountPrice = values.ProductPrice - values.ProductPrice / 100 * coupon.Rate;
            discountPrice = Math.Ceiling(discountPrice);

            updateBannerDto.ProductName = values.ProductName;
            updateBannerDto.ProductPrice = decimal.Parse(discountPrice.ToString("F2"));

            await _bannerService.UpdateBannerAsync(updateBannerDto);
            return RedirectToAction("Index", "Banner", new { area = "Administrator" });
        }
    }
}
