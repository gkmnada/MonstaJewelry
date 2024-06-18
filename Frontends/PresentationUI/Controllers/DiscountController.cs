using BusinessLayer.Basket;
using BusinessLayer.Discount.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> ApplyCouponCode(string code)
        {
            var coupon = await _discountService.GetCouponCodeAsync(code);
            int couponRate = coupon.Rate;

            var basket = await _basketService.GetBasketAsync();

            var totalPrice = basket.TotalPrice;
            var discountRate = coupon.Rate;

            var discountPrice = Math.Round(totalPrice - (totalPrice * couponRate / 100));
            discountPrice = decimal.Parse(discountPrice.ToString("F2"));

            var taxPrice = Math.Round(discountPrice / 100 * 18);
            taxPrice = decimal.Parse(taxPrice.ToString("F2"));

            var total = Math.Round(discountPrice + taxPrice);
            total = decimal.Parse(total.ToString("F2"));

            return Json(new { discountRate, discountPrice, taxPrice, total });
        }
    }
}
