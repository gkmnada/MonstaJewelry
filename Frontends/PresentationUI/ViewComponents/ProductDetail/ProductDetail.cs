using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Catalog.ProductImageService;
using BusinessLayer.Discount.DiscountServices;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Models;

namespace PresentationUI.ViewComponents.ProductDetail
{
    public class ProductDetail : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;
        private readonly IDiscountService _discountService;

        public ProductDetail(IProductDetailService productDetailService, IProductImageService productImageService, IDiscountService discountService)
        {
            _productDetailService = productDetailService;
            _productImageService = productImageService;
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id, string code)
        {
            var details = await _productDetailService.GetProductDetailWithProductAsync(id);
            var images = await _productImageService.GetProductImageWithProductAsync(id);

            ViewBag.Coupon = code;

            var values = await _discountService.GetCouponCodeAsync(code);

            ViewBag.Price = details.Product.ProductPrice;
            var discountPrice = Math.Round(details.Product.ProductPrice - (details.Product.ProductPrice * values.Rate / 100));
            discountPrice = decimal.Parse(discountPrice.ToString("F2"));

            ViewBag.DiscountPrice = discountPrice;

            var productDetailViewModel = new ProductDetailViewModel
            {
                GetProductDetailDto = details,
                GetProductImageDto = images
            };
            return View(productDetailViewModel);
        }
    }
}
