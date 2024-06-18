using BusinessLayer.Basket;
using BusinessLayer.Catalog.ProductServices;
using BusinessLayer.Discount.DiscountServices;
using DtoLayer.BasketDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Models;

namespace PresentationUI.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;

        public BasketController(IBasketService basketService, IProductService productService, IDiscountService discountService)
        {
            _basketService = basketService;
            _productService = productService;
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string code)
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
                ViewBag.DiscountRate = "Kupon İndirimi: %" + discountRate;
                ViewBag.CouponCode = code;

                var basketViewModel = new BasketViewModel
                {
                    BasketItemDto = basketItem,
                };
                return View(basketViewModel);
            }
        }

        public async Task<IActionResult> AddBasketItem(string id, string code)
        {
            if (code == null)
            {
                var values = await _productService.GetProductAsync(id);

                var productPrice = Math.Round(values.ProductPrice);
                productPrice = decimal.Parse(productPrice.ToString("F2"));

                var item = new BasketItemDto
                {
                    ProductID = values.ProductID,
                    ProductName = values.ProductName,
                    ProductImage = values.ProductImage,
                    Quantity = 1,
                    Price = productPrice,
                };
                await _basketService.AddBasketItemAsync(item);
                return RedirectToAction("Index");
            }
            else
            {
                var values = await _productService.GetProductAsync(id);
                var coupon = await _discountService.GetCouponCodeAsync(code);

                var discountPrice = Math.Round(values.ProductPrice - (values.ProductPrice / 100 * coupon.Rate));
                discountPrice = decimal.Parse(discountPrice.ToString("F2"));

                var item = new BasketItemDto
                {
                    ProductID = values.ProductID,
                    ProductName = values.ProductName,
                    ProductImage = values.ProductImage,
                    Quantity = 1,
                    Price = discountPrice,
                };
                await _basketService.AddBasketItemAsync(item);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItemAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasketAsync();
            return NoContent();
        }
    }
}
