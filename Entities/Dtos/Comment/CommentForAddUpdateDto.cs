using Core.Entities.Abstract;

namespace Entities.Dtos.Comment
{
    public class CommentForAddUpdateDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleID { get; set; }
        public string CommentText { get; set; }
    }
}