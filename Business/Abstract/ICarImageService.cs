using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImageDetailDto>> GetAllCarImageDetails();
        IDataResult<CarImageDetailDto> GetCarImageDetailsById(int carImageId);
    }
}
