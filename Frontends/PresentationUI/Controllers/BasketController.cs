using BusinessLayer.Basket;
using BusinessLayer.Catalog.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Models;

namespace PresentationUI.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await _basketService.GetBasketAsync();
            var basketItem = basket.BasketItem;

            var basketViewModel = new BasketViewModel
            {
                BasketItemDto = basketItem,
            };
            return View(basketViewModel);
        }
    }
}
