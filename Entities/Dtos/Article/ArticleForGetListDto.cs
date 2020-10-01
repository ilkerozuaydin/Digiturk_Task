using Core.Entities.Abstract;

namespace Entities.Dtos.Article
{
    public class ArticleForGetListDto : IDto
    {
        public int UserId { get; set; }
    }
}