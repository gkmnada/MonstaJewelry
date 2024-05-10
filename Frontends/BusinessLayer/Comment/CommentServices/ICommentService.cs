using DtoLayer.CommentDto.UserCommentDto;

namespace BusinessLayer.Comment.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> ListCommentAsync(string id);
        Task CreateCommentAsync(CreateCommentDto createUserCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateUserCommentDto);
        Task DeleteCommentAsync(string id);
        Task<GetCommentDto> GetCommentWithProductAsync(string id);
        Task<GetCommentDto> GetCommentAsync(string id);
    }
}
