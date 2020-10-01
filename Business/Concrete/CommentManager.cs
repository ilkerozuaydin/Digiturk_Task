using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect]
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [CacheRemoveAspect("ICommentService.Get")]
        public async Task<IResult> Add(CommentForAddUpdateDto dto)
        {
            await _commentDal.AddAsync(dto.Map<Comment>());
            return new SuccessResult(Messages.AddedSuccessfully);
        }

        [CacheRemoveAspect("ICommentService.Get")]
        public async Task<IResult> Update(CommentForAddUpdateDto dto)
        {
            var isCommentExists = await _commentDal.GetAsync(c => c.Id == dto.Id);
            if (isCommentExists == null)
            {
                return new ErrorResult(Messages.CommentNotFound);
            }
            await _commentDal.UpdateAsync(dto.Map(isCommentExists));
            return new SuccessResult(Messages.UpdatedSuccessfully);
        }

        [CacheRemoveAspect("ICommentService.Get")]
        public async Task<IResult> Delete(CommentForDeleteDto dto)
        {
            var isCommentExists = await _commentDal.GetAsync(c => c.Id == dto.Id);
            if (isCommentExists == null)
            {
                return new ErrorResult(Messages.CommentNotFound);
            }

            await _commentDal.DeleteAsync(isCommentExists);
            return new SuccessResult(Messages.DeletedSuccessfully);
        }

        [CacheAspect(duration: 100)]
        public async Task<IDataResult<Comment>> GetComment(CommentForGetDto dto)
        {
            return new SuccessDataResult<Comment>(await _commentDal.GetAsync(c => c.Id == dto.Id));
        }

        [CacheAspect(duration: 100)]
        public async Task<IDataResult<List<Comment>>> GetCommentList(CommentForGetListDto dto)
        {
            return new SuccessDataResult<List<Comment>>(await _commentDal.GetListAsync(c => c.ArticleID == dto.ArticleId));
        }
    }
}