using BusinessLayer.Discount.DiscountServices;
using DtoLayer.DiscountDto.CouponDto;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IActionResult> Index()
        {
            var discounts = await _discountService.ListCouponAsync();
            return View(discounts);
        }

        [HttpGet]
        public IActionResult CreateCoupon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return RedirectToAction("Index", "Discount", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return RedirectToAction("Index", "Discount", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCoupon(int id)
        {
            var values = await _discountService.GetCouponAsync(id);

            ViewBag.IsActive = values.IsActive;

            var discountViewModel = new DiscountViewModel
            {
                GetCouponDto = values
            };
            return View(discountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return RedirectToAction("Index", "Discount", new { area = "Administrator" });
        }
    }
}
