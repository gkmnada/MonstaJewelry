using BusinessLayer.Catalog.ProductServices;
using BusinessLayer.Catalog.SliderServices;
using BusinessLayer.Discount.DiscountServices;
using DtoLayer.CatalogDto.SliderDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IDiscountService _discountService;
        private readonly IProductService _productService;

        public SliderController(ISliderService sliderService, IDiscountService discountService, IProductService productService)
        {
            _sliderService = sliderService;
            _discountService = discountService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _sliderService.ListSliderAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSlider()
        {
            var discounts = await _discountService.ListCouponAsync();
            var products = await _productService.ListProductAsync();

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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(IFormFile CoverImage, CreateSliderDto createSliderDto)
        {
            if (CoverImage != null && CoverImage.Length > 0)
            {
                var fileName = Path.GetFileName(CoverImage.FileName);
                var filePath = Path.Combine("wwwroot/images/slider/" + fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await CoverImage.CopyToAsync(stream);
                }
                createSliderDto.ProductImage = "/images/slider/" + fileName;

                var values = await _productService.GetProductAsync(createSliderDto.ProductID);
                var coupon = await _discountService.GetCouponCodeAsync(createSliderDto.CouponCode);

                var discountPrice = values.ProductPrice - values.ProductPrice / 100 * coupon.Rate;
                discountPrice = Math.Ceiling(discountPrice);

                createSliderDto.ProductName = values.ProductName;
                createSliderDto.ProductPrice = decimal.Parse(discountPrice.ToString("F2"));

                await _sliderService.CreateSliderAsync(createSliderDto);
                return RedirectToAction("Index", "Slider", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction("Index", "Slider", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(string id)
        {
            var discounts = await _discountService.ListCouponAsync();
            var products = await _productService.ListProductAsync();

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

            var values = await _sliderService.GetSliderAsync(id);

            ViewBag.SelectedCode = values.CouponCode;
            ViewBag.SelectedProduct = values.ProductID;

            var sliderViewModel = new SliderViewModel
            {
                GetSliderDto = values
            };
            return View(sliderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(IFormFile CoverImage, UpdateSliderDto updateSliderDto)
        {
            if (CoverImage != null && CoverImage.Length > 0)
            {
                var fileName = Path.GetFileName(CoverImage.FileName);
                var filePath = Path.Combine("wwwroot/images/slider/" + fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await CoverImage.CopyToAsync(stream);
                }
                updateSliderDto.ProductImage = "/images/slider/" + fileName;
            }
            else
            {
                var existingImage = await _sliderService.GetSliderAsync(updateSliderDto.SliderID);
                updateSliderDto.ProductImage = existingImage.ProductImage;
            }
            var values = await _productService.GetProductAsync(updateSliderDto.ProductID);
            var coupon = await _discountService.GetCouponCodeAsync(updateSliderDto.CouponCode);

            var discountPrice = values.ProductPrice - values.ProductPrice / 100 * coupon.Rate;
            discountPrice = Math.Ceiling(discountPrice);

            updateSliderDto.ProductName = values.ProductName;
            updateSliderDto.ProductPrice = decimal.Parse(discountPrice.ToString("F2"));

            await _sliderService.UpdateSliderAsync(updateSliderDto);
            return RedirectToAction("Index", "Slider", new { area = "Administrator" });
        }
    }
}
