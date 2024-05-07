using CommentAPI.Dtos.UserCommentDto;

namespace CommentAPI.Services
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> ListCommentAsync(string id);
        Task CreateCommentAsync(CreateCommentDto createUserCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateUserCommentDto);
        Task DeleteCommentAsync(int id);
        Task<GetCommentDto> GetCommentWithProductAsync(string id);
        Task<GetCommentDto> GetCommentAsync(int id);
    }
}
