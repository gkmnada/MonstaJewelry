using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Catalog.ProductImageService;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Models;

namespace PresentationUI.ViewComponents.Product
{
    public class Modal : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;

        public Modal(IProductDetailService productDetailService, IProductImageService productImageService)
        {
            _productDetailService = productDetailService;
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var details = await _productDetailService.GetProductDetailWithProductAsync(id);
            var images = await _productImageService.GetProductImageWithProductAsync(id);

            var productDetailViewModel = new ProductDetailViewModel
            {
                GetProductDetailDto = details,
                GetProductImageDto = images
            };
            return View(productDetailViewModel);
        }
    }
}
