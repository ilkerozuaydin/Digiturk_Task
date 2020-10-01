using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetUserList();

        Task<IDataResult<User>> GetUser(UserForGetDto user);

        Task<IResult> Update(UserForAddUpdateDto user);

        Task<IResult> Delete(UserForDeleteDto user);

        Task<IDataResult<User>> GetByMail(string email);

        Task<IDataResult<AccessToken>> Login(UserForLoginDto user);

        Task<IResult> Register(UserForAddUpdateDto user);
    }
}