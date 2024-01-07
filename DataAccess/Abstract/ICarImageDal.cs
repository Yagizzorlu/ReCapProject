using Core.DataAccess;
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
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<CarImageDetailDto> GetAllCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null);
        CarImageDetailDto GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter);
    }
}
