using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllCarsByBrandId(int brandId);
        List<Car> GetAllCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetailDtos();
    }
}
