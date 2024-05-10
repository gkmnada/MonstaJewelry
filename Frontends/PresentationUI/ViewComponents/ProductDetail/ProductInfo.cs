using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Comment.CommentServices;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Models;

namespace PresentationUI.ViewComponents.ProductDetail
{
    public class ProductInfo : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly IProductDetailService _productDetailService;

        public ProductInfo(ICommentService commentService, IProductDetailService productDetailService)
        {
            _commentService = commentService;
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var details = await _productDetailService.GetProductDetailWithProductAsync(id);
            var comments = await _commentService.ListCommentAsync(id);

            var productDetailViewModel = new ProductDetailViewModel
            {
                GetProductDetailDto = details,
                ResultCommentDto = comments
            };
            return View(productDetailViewModel);
        }
    }
}
