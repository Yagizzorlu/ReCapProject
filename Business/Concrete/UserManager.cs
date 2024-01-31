using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public partial class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        //public IResult Delete(User user)
        //{
        //    _userDal.Delete(user);
        //    return new SuccessResult(Messages.UserDeleted);
        //}


        //[SecuredOperation("admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<UserInfoDto>> GetAllInfos()
        {
            return new SuccessDataResult<List<UserInfoDto>>(_userDal.GetAllUserInfos());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<UserInfoDto> GetByInfoId(int userId)
        {
            return new SuccessDataResult<UserInfoDto>(_userDal.GetUserInfos(u => u.UserId == userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        //public IResult Update(User user)
        //{
        //    _userDal.Add(user);
        //    return new SuccessResult(Messages.UserUpdated);
        //}
    }
}
