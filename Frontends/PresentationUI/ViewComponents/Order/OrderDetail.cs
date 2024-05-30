using BusinessLayer.Basket;
using BusinessLayer.Discount.DiscountServices;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Models;

namespace PresentationUI.ViewComponents.Order
{
    public class OrderDetail : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;

        public OrderDetail(IBasketService basketService, IDiscountService discountService)
        {
            _basketService = basketService;
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string code)
        {
            if (code == null)
            {
                var basket = await _basketService.GetBasketAsync();
                var basketItem = basket.BasketItem;

                ViewBag.TotalPrice = basket.TotalPrice;

                var taxPrice = Math.Round(basket.TotalPrice / 100 * 18, 2);
                ViewBag.TaxPrice = taxPrice;

                var total = Math.Round(basket.TotalPrice + taxPrice, 2);
                ViewBag.Total = total;

                var basketViewModel = new BasketViewModel
                {
                    BasketItemDto = basketItem,
                };
                return View(basketViewModel);
            }
            else
            {
                var basket = await _basketService.GetBasketAsync();
                var basketItem = basket.BasketItem;

                var coupon = await _discountService.GetCouponCodeAsync(code);
                int couponRate = coupon.Rate;

                var totalPrice = basket.TotalPrice;
                var discountRate = coupon.Rate;

                var discountPrice = Math.Round(totalPrice - totalPrice / 100 * couponRate, 2);
                var taxPrice = Math.Round(discountPrice / 100 * 18, 2);
                var total = Math.Round(discountPrice + taxPrice, 2);

                ViewBag.TotalPrice = discountPrice;
                ViewBag.TaxPrice = taxPrice;
                ViewBag.Total = total;
                ViewBag.DiscountRate = "Kupon İndirimi: %" + discountRate;

                var basketViewModel = new BasketViewModel
                {
                    BasketItemDto = basketItem,
                };
                return View(basketViewModel);
            }
        }
    }
}
