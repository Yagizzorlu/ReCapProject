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
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetAllCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetAllCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
