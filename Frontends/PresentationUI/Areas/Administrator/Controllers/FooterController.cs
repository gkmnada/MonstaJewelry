using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.FooterServices;
using BusinessLayer.Catalog.ProductServices;
using BusinessLayer.Discount.DiscountServices;
using DtoLayer.CatalogDto.FooterDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class FooterController : Controller
    {
        private readonly IFooterService _footerService;
        private readonly IDiscountService _discountService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FooterController(IFooterService footerService, IDiscountService discountService, IProductService productService, ICategoryService categoryService)
        {
            _footerService = footerService;
            _discountService = discountService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _footerService.ListFooterWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateFooter()
        {
            var products = await _productService.ListProductAsync();
            var coupons = await _discountService.ListCouponAsync();
            var categories = await _categoryService.ListCategoryAsync();

            List<SelectListItem> listProduct = (from x in products
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductID
                                                }).ToList();

            ViewBag.Product = listProduct;

            List<SelectListItem> listCoupon = (from x in coupons
                                               select new SelectListItem
                                               {
                                                   Text = x.Code,
                                                   Value = x.Code
                                               }).ToList();

            ViewBag.Discount = listCoupon;

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
        public async Task<IActionResult> CreateFooter(CreateFooterDto createFooterDto)
        {
            var products = await _productService.GetProductAsync(createFooterDto.ProductID);

            createFooterDto.ProductName = products.ProductName;
            createFooterDto.ProductImage = products.ProductImage;
            createFooterDto.ProductPrice = products.ProductPrice;

            var coupon = await _discountService.GetCouponCodeAsync(createFooterDto.CouponCode);
            var discountPrice = products.ProductPrice - products.ProductPrice / 100 * coupon.Rate;
            discountPrice = Math.Ceiling(discountPrice);

            createFooterDto.DiscountPrice = decimal.Parse(discountPrice.ToString("F2"));

            await _footerService.CreateFooterAsync(createFooterDto);
            return RedirectToAction("Index", "Footer", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteFooter(string id)
        {
            await _footerService.DeleteFooterAsync(id);
            return RedirectToAction("Index", "Footer", new { area = "Administrator" });
        }
    }
}
