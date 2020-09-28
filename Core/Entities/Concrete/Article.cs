using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Article:IEntity
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UserId { get; set; }
        public string ArticleText { get; set; }


        public virtual User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
