using Microsoft.AspNetCore.SignalR;
using PresentationUI.TableDependencies.Services;

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
            var values = _commentService.GetCommentCount(id);
            await Clients.All.SendAsync("ReceiveCommentCount", values);
        }
    }
}
