using CommentAPI.Dtos.UserCommentDto;
using CommentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommentAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> ListComment(string id)
        {
            var values = await _commentService.ListCommentAsync(id);
            return Ok(values);
        }

        [HttpGet("GetComment")]
        public async Task<IActionResult> GetComment(string id)
        {
            var values = await _commentService.GetCommentAsync(id);
            return Ok(values);
        }

        [HttpGet("GetCommentWithProduct")]
        public async Task<IActionResult> GetCommentWithProduct(string id)
        {
            var values = await _commentService.GetCommentWithProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            await _commentService.CreateCommentAsync(createCommentDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return Ok("Başarılı");
        }

        [HttpGet("GetCommentCount")]
        public async Task<IActionResult> GetCommentCount(string id)
        {
            var values = await _commentService.GetCommentCountAsync(id);
            return Ok(values);
        }
    }
}
