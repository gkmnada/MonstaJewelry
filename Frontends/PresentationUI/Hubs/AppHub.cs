using BusinessLayer.Comment.CommentServices;
using Microsoft.AspNetCore.SignalR;

namespace PresentationUI.Hubs
{
    public class AppHub : Hub
    {
        private readonly ICommentService _commentService;

        public AppHub(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task SendCommentCount(string id)
        {
            var commentCount = await _commentService.GetCommentCountAsync(id);
            await Clients.All.SendAsync("ReceiveCommentCount", commentCount);
        }
    }
}
