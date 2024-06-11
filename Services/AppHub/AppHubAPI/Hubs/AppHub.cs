using BusinessLayer.Comment.CommentServices;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace AppHubAPI.Hubs
{
    public class AppHub : Hub
    {
        private readonly IHttpClientFactory _clientFactory;

        public AppHub(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task SendCommentCount(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7080/api/Comment/GetCommentCount?id=" + id);
            var commentCount = await response.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCommentCount", commentCount);
        }
    }
}
