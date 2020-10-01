using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<List<Comment>>> GetCommentList(CommentForGetListDto dto);

        Task<IDataResult<Comment>> GetComment(CommentForGetDto dto);

        Task<IResult> Add(CommentForAddUpdateDto dto);

        Task<IResult> Update(CommentForAddUpdateDto dto);

        Task<IResult> Delete(CommentForDeleteDto dto);
    }
}