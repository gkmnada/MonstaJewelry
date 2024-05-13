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

        [HttpPost]
        public async Task<IActionResult> ApplyCouponCode(string code)
        {
            var coupon = await _discountService.GetCouponCodeAsync(code);
            int couponRate = coupon.Rate;

            var basket = await _basketService.GetBasketAsync();

            var totalPrice = basket.TotalPrice;
            var discountPrice = totalPrice - totalPrice / 100 * couponRate;
            var taxPrice = discountPrice / 100 * 18;
            var total = discountPrice + taxPrice;

            return NoContent();
        }
    }
}
