using Core.DataAccess.EntityFramework;
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
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarRentalContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetAllCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null)
        {
            using(CarRentalContext context = new CarRentalContext()) 
            {
                var result = from brand in context.Brands
                             join model in context.Models on brand.BrandId equals model.BrandId
                             join car in context.Cars on brand.BrandId equals car.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             select new CarImageDetailDto
                             {
                                 Id = carImage.CarImageId,
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 ModelName = model.ModelName,
                                 ColorName = color.ColorName,
                                 ModelYear = model.ModelYear,
                                 ImagePath = carImage.CarImagePath,
                                 Date = carImage.CarImageDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CarImageDetailDto GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from brand in context.Brands
                             join model in context.Models on brand.BrandId equals model.BrandId
                             join car in context.Cars on brand.BrandId equals car.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.CarId equals carImage.CarId
                             select new CarImageDetailDto
                             {
                                 Id = carImage.CarImageId,
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 ModelName = model.ModelName,
                                 ColorName = color.ColorName,
                                 ModelYear = model.ModelYear,
                                 ImagePath = carImage.CarImagePath,
                                 Date = carImage.CarImageDate
                             };
                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
