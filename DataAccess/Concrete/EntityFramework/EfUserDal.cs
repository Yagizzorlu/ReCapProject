using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<UserInfoDto> GetAllUserInfos(Expression<Func<UserInfoDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = (from user in context.Users
                              select new UserInfoDto
                              {
                                  UserId = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  Status = user.Status,
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }


        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRentalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }

        public UserInfoDto GetUserInfos(System.Linq.Expressions.Expression<Func<UserInfoDto, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = (from user in context.Users
                              select new UserInfoDto
                              {
                                  UserId = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  Status = user.Status,
                              });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}

