using Core.Entities.Abstract;
using System;

namespace Core.Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleID { get; set; }
        public string CommentText { get; set; }
        public DateTime CreateDateTime { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}