using DtoLayer.CommentDto.UserCommentDto;
using System.Net.Http.Json;

namespace BusinessLayer.Comment.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _client;

        public CommentService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateCommentAsync(CreateCommentDto createUserCommentDto)
        {
            await _client.PostAsJsonAsync("comment", createUserCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _client.DeleteAsync("comment?id=" + id);
        }

        public async Task<GetCommentDto> GetCommentAsync(string id)
        {
            var responseMessage = await _client.GetAsync("comment/getcomment?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<GetCommentDto>();
        }

        public async Task<int> GetCommentCountAsync(string id)
        {
            var responseMessage = await _client.GetAsync("comment/getcommentcount?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<int>();
        }

        public async Task<GetCommentDto> GetCommentWithProductAsync(string id)
        {
            var responseMessage = await _client.GetAsync("comment/getcommentwithproduct?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<GetCommentDto>();
        }

        public async Task<List<ResultCommentDto>> ListCommentAsync(string id)
        {
            var responseMessage = await _client.GetAsync("comment?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateUserCommentDto)
        {
            await _client.PutAsJsonAsync("comment", updateUserCommentDto);
        }
    }
}
