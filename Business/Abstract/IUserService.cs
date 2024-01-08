using Core.Entities.Concrete;
using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<UserInfoDto>> GetAllInfos();
        IDataResult<UserInfoDto> GetByInfoId(int userId);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        //IResult Update(User user);
        //IResult Delete(User user);
    }
}
