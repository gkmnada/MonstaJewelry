using BusinessLayer.Basket;
using BusinessLayer.Catalog.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace PresentationUI.ViewComponents.Layout
{
    public class Header : ViewComponent
    {
        public readonly ICategoryService _categoryService;
        private readonly IBasketService _basketService;

        public Header(ICategoryService categoryService, IBasketService basketService)
        {
            _categoryService = categoryService;
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.ListCategoryAsync();

            int basketCount = 0;
            decimal totalPrice = 0;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                basketCount = await _basketService.GetBasketCountAsync();
                var totalBasket = await _basketService.GetBasketAsync();
                totalPrice = totalBasket.TotalPrice;
            }

            var numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = string.Empty
            };

            ViewBag.BasketCount = basketCount;
            ViewBag.TotalPrice = Math.Round(totalPrice, 2).ToString("N2", numberFormatInfo);
            return View(values);
        }
    }
}
