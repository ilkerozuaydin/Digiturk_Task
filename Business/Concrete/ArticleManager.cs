using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Article;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect]
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        [CacheRemoveAspect("IArticleService.Get")]
        public async Task<IResult> Add(ArticleForAddUpdateDto dto)
        {
            var isExistsArticle = await _articleDal.GetAsync(a => a.Name == dto.Name);
            if (isExistsArticle != null)
            {
                return new ErrorResult(Messages.ArticleNameAlreadyExist);
            }

            await _articleDal.AddAsync(dto.Map<Article>());
            return new SuccessResult(Messages.AddedSuccessfully);
        }

        [CacheRemoveAspect("IArticleService.Get")]
        public async Task<IResult> Delete(ArticleForDeleteDto dto)
        {
            var isExistsArticle = await _articleDal.GetAsync(a => a.Id == dto.Id);
            if (isExistsArticle == null)
            {
                return new ErrorResult(Messages.ArticleNotFound);
            }
            await _articleDal.DeleteAsync(isExistsArticle);
            return new SuccessResult(Messages.DeletedSuccessfully);
        }

        [CacheAspect(duration: 100)]
        public async Task<IDataResult<Article>> GetArticle(ArticleForGetDto dto)
        {
            return new SuccessDataResult<Article>(await _articleDal.GetAsync(a => a.Id == dto.Id));
        }

        [CacheAspect(duration: 100)]
        public async Task<IDataResult<List<Article>>> GetArticleList(ArticleForGetListDto dto)
        {
            return new SuccessDataResult<List<Article>>(await _articleDal.GetListAsync(a => a.UserId == dto.UserId));
        }

        [CacheRemoveAspect("IArticleService.Get")]
        public async Task<IResult> Update(ArticleForAddUpdateDto dto)
        {
            var isExistsArticle = await _articleDal.GetAsync(a => a.Id == dto.Id);
            if (isExistsArticle == null)
            {
                return new ErrorResult(Messages.ArticleNotFound);
            }

            await _articleDal.UpdateAsync(dto.Map<Article>());
            return new SuccessResult(Messages.UpdatedSuccessfully);
        }
    }
}