using CommentAPI.Context;
using CommentAPI.Dtos.UserCommentDto;
using CommentAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommentAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentContext _context;

        public CommentService(CommentContext context)
        {
            _context = context;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var userComment = new UserComment
            {
                NameSurname = createCommentDto.NameSurname,
                Image = createCommentDto.Image,
                Email = createCommentDto.Email,
                Comment = createCommentDto.Comment,
                Rating = createCommentDto.Rating,
                CommentDate = DateTime.Now,
                Status = true,
                ProductID = createCommentDto.ProductID
            };
            await _context.UserComment.AddAsync(userComment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(string id)
        {
            var userComment = await _context.UserComment.FirstOrDefaultAsync(x => x.UserCommentID == id);
            _context.UserComment.Remove(userComment);
            await _context.SaveChangesAsync();
        }

        public async Task<GetCommentDto> GetCommentAsync(string id)
        {
            var userComment = await _context.UserComment.FirstOrDefaultAsync(x => x.UserCommentID == id);
            var getCommentDto = new GetCommentDto
            {
                UserCommentID = userComment.UserCommentID,
                NameSurname = userComment.NameSurname,
                Image = userComment.Image,
                Email = userComment.Email,
                Comment = userComment.Comment,
                Rating = userComment.Rating,
                CommentDate = userComment.CommentDate,
                Status = userComment.Status,
                ProductID = userComment.ProductID
            };
            return getCommentDto;
        }

        public async Task<GetCommentDto> GetCommentWithProductAsync(string id)
        {
            var userComment = await _context.UserComment.FirstOrDefaultAsync(x => x.ProductID == id);
            var getCommentDto = new GetCommentDto
            {
                UserCommentID = userComment.UserCommentID,
                NameSurname = userComment.NameSurname,
                Image = userComment.Image,
                Email = userComment.Email,
                Comment = userComment.Comment,
                Rating = userComment.Rating,
                CommentDate = userComment.CommentDate,
                Status = userComment.Status,
                ProductID = userComment.ProductID
            };
            return getCommentDto;
        }

        public async Task<List<ResultCommentDto>> ListCommentAsync(string id)
        {
            var userComments = await _context.UserComment.Where(x => x.ProductID == id).ToListAsync();
            var resultCommentDtos = new List<ResultCommentDto>();
            foreach (var userComment in userComments)
            {
                var resultCommentDto = new ResultCommentDto
                {
                    UserCommentID = userComment.UserCommentID,
                    NameSurname = userComment.NameSurname,
                    Image = userComment.Image,
                    Email = userComment.Email,
                    Comment = userComment.Comment,
                    Rating = userComment.Rating,
                    CommentDate = userComment.CommentDate,
                    Status = userComment.Status,
                    ProductID = userComment.ProductID
                };
                resultCommentDtos.Add(resultCommentDto);
            }
            return resultCommentDtos;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var userComment = await _context.UserComment.FindAsync(updateCommentDto.UserCommentID);
            userComment.NameSurname = updateCommentDto.NameSurname;
            userComment.Image = updateCommentDto.Image;
            userComment.Email = updateCommentDto.Email;
            userComment.Comment = updateCommentDto.Comment;
            userComment.Rating = updateCommentDto.Rating;
            userComment.CommentDate = DateTime.Now;
            userComment.Status = updateCommentDto.Status;
            userComment.ProductID = updateCommentDto.ProductID;
            _context.UserComment.Update(userComment);
            await _context.SaveChangesAsync();
        }
    }
}
