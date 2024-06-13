using BusinessLayer.Comment.CommentServices;
using DtoLayer.CommentDto.UserCommentDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.Image = "/images/profile/_unknown.webp";
            createCommentDto.CommentDate = DateTime.Now;
            createCommentDto.Status = true;

            await _commentService.CreateCommentAsync(createCommentDto);
            return Json(createCommentDto);
        }

        public async Task<IActionResult> ListComment(string id)
        {
            var values = await _commentService.ListCommentAsync(id);
            return Json(values);
        }
    }
}
