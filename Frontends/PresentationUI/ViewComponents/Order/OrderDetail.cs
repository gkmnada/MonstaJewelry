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

        public async Task<IViewComponentResult> InvokeAsync(string code, string address)
        {
            if (code == null)
            {
                var basket = await _basketService.GetBasketAsync();
                var basketItem = basket.BasketItem;

                var totalPrice = Math.Round(basket.TotalPrice);
                totalPrice = decimal.Parse(totalPrice.ToString("F2"));

                ViewBag.TotalPrice = totalPrice;

                var taxPrice = Math.Round(totalPrice / 100 * 18);
                taxPrice = decimal.Parse(taxPrice.ToString("F2"));

                ViewBag.TaxPrice = taxPrice;

                var total = Math.Round(totalPrice + taxPrice);
                total = decimal.Parse(total.ToString("F2"));

                ViewBag.Total = total;

                ViewBag.Address = address;

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

                var discountPrice = Math.Round(totalPrice - (totalPrice * couponRate / 100));
                discountPrice = decimal.Parse(discountPrice.ToString("F2"));

                var taxPrice = Math.Round(discountPrice / 100 * 18);
                taxPrice = decimal.Parse(taxPrice.ToString("F2"));

                var total = Math.Round(discountPrice + taxPrice);
                total = decimal.Parse(total.ToString("F2"));

                ViewBag.TotalPrice = discountPrice;
                ViewBag.TaxPrice = taxPrice;
                ViewBag.Total = total;
                ViewBag.DiscountRate = "Kupon İndirimi: %" + "(" + discountRate + ")";
                ViewBag.Code = code;

                ViewBag.Address = address;

                var basketViewModel = new BasketViewModel
                {
                    BasketItemDto = basketItem,
                };
                return View(basketViewModel);
            }
        }
    }
}
