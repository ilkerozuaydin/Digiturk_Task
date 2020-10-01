using Core.Entities.Abstract;

namespace Entities.Dtos.Comment
{
    public class CommentForGetListDto : IDto
    {
        public int ArticleId { get; set; }
    }
}