using DtoLayer.CatalogDto.ProductDto;
using DtoLayer.CommentDto.UserCommentDto;

namespace PresentationUI.Areas.Administrator.Models
{
    public class CommentViewModel
    {
        public GetProductDto GetProductDto { get; set; }
        public CreateCommentDto CreateCommentDto { get; set; }
        public GetCommentDto GetCommentDto { get; set; }
        public UpdateCommentDto UpdateCommentDto { get; set; }
    }
}
