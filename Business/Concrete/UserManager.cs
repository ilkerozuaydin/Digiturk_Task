using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using Entities.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect]
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;

        public UserManager(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        [CacheRemoveAspect("IUserService.Get")]
        public async Task<IResult> Delete(UserForDeleteDto user)
        {
            var isUserExists = await _userDal.GetAsync(u => u.Id == user.Id);
            if (isUserExists != null)
            {
                await _userDal.DeleteAsync(isUserExists);
                return new SuccessResult(Messages.DeletedSuccessfully);
            }
            else
            {
                return new ErrorResult(Messages.UserNotFound);
            }
        }

        [CacheAspect(duration: 100)]
        public async Task<IDataResult<User>> GetByMail(string email)
        {
            return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.Email == email));
        }

        [CacheAspect(duration: 100)]
        public async Task<IDataResult<User>> GetUser(UserForGetDto user)
        {
            var dbUser = await _userDal.GetAsync(u => u.Id == user.Id);
            return new SuccessDataResult<User>(dbUser);
        }

        [CacheAspect(duration: 100)]
        public async Task<IDataResult<List<User>>> GetUserList()
        {
            var response = new SuccessDataResult<List<User>>(await _userDal.GetListAsync());
            return response;
        }

        public async Task<IDataResult<AccessToken>> Login(UserForLoginDto user)
        {
            var userToCheck = await GetByMail(user.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<AccessToken>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(user.Password, userToCheck.Data.Password, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<AccessToken>(Messages.PasswordError);
            }

            var tokenData = _tokenHelper.CreateToken(userToCheck.Data);
            return new SuccessDataResult<AccessToken>(tokenData, Messages.LoginSuccessful);
        }

        [CacheRemoveAspect("IUserService.Get")]
        public async Task<IResult> Register(UserForAddUpdateDto user)
        {
            byte[] passwordHash, passwordSalt;
            var mailControl = await this.GetByMail(user.Email);
            if (mailControl.Success)
            {
                if (mailControl.Data != null)
                {
                    return new ErrorResult(Messages.UserAlreadyExist);
                }
                else
                {
                    HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                    var newUser = new User
                    {
                        Email = user.Email,
                        Name = user.Name,
                        Password = passwordHash,
                        PasswordSalt = passwordSalt
                    };
                    await _userDal.AddAsync(newUser);

                    return new SuccessResult(Messages.AddedSuccessfully);
                }
            }
            else
            {
                return new ErrorResult(Messages.SystemError);
            }
        }

        [CacheRemoveAspect("IUserService.Get")]
        public async Task<IResult> Update(UserForAddUpdateDto user)
        {
            var isUserExists = await _userDal.GetAsync(u => u.Id == user.Id);
            if (isUserExists == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            await _userDal.UpdateAsync(user.Map(isUserExists));
            return new SuccessResult(Messages.UpdatedSuccessfully);
        }
    }
}