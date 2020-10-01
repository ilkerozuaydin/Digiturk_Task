using Core.Entities.Abstract;

namespace Entities.Dtos.Article
{
    public class ArticleForAddUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string ArticleText { get; set; }
    }
}