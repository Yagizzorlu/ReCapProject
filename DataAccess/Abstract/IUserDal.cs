using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim>GetClaims(User user);
        List<UserInfoDto> GetAllUserInfos(Expression<Func<UserInfoDto, bool>> filter = null);
        UserInfoDto GetUserInfos(Expression<Func<UserInfoDto, bool>> filter);
    }
}
