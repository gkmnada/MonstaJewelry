using BusinessLayer.Catalog.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.ProductDetail
{
    public class RelatedProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public RelatedProducts(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.ListProductByCategoryAsync(id);
            return View(values);
        }
    }
}
