namespace DtoLayer.CommentDto.UserCommentDto
{
    public class GetCommentDto
    {
        public string UserCommentID { get; set; }
        public string NameSurname { get; set; }
        public string? Image { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }
        public string ProductID { get; set; }
    }
}
