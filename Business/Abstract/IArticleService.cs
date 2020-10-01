using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<List<Article>>> GetArticleList(ArticleForGetListDto dto);

        Task<IDataResult<Article>> GetArticle(ArticleForGetDto dto);

        Task<IResult> Add(ArticleForAddUpdateDto dto);

        Task<IResult> Update(ArticleForAddUpdateDto dto);

        Task<IResult> Delete(ArticleForDeleteDto dto);
    }
}