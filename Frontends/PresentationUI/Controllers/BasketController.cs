using BusinessLayer.Basket;
using BusinessLayer.Catalog.ProductServices;
using DtoLayer.BasketDto;
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

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetProductAsync(id);
            var item = new BasketItemDto
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductImage = values.ProductImage,
                Quantity = 1,
                Price = values.ProductPrice,
            };
            await _basketService.AddBasketItemAsync(item);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItemAsync(id);
            return RedirectToAction("Index");
        }
    }
}
