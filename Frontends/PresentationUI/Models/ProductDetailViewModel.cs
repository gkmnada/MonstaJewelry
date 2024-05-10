using DtoLayer.CatalogDto.ProductDetailDto;
using DtoLayer.CatalogDto.ProductImageDto;
using DtoLayer.CommentDto.UserCommentDto;

namespace PresentationUI.Models
{
    public class ProductDetailViewModel
    {
        public GetProductDetailDto GetProductDetailDto { get; set; }
        public GetProductImageDto GetProductImageDto { get; set; }
        public List<ResultCommentDto> ResultCommentDto { get; set; }
    }
}
