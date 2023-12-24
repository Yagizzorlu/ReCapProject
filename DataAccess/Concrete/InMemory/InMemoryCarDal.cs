using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {

            _cars = new List<Car> {
                new Car{CarId = 1 , BrandId = 1 , ColorId = 1 , DailyPrice = 7000 , Description = "Sıfır Model Otomatik Vites" , ModelYear = 2016 },
                new Car{CarId = 2 , BrandId = 2 , ColorId = 2 , DailyPrice = 4500 , Description = "İkinci El Otomatik Vites" ,   ModelYear = 2017 },
                new Car{CarId = 3 , BrandId = 4 , ColorId = 1 , DailyPrice = 3500 , Description = "İkinci El Manuel Vites" ,     ModelYear = 2013 },
                new Car{CarId = 4 , BrandId = 3 , ColorId = 3 , DailyPrice = 6250 , Description = "Sıfır Model Manuel Vites" ,   ModelYear = 2018 },
                new Car{CarId = 5 , BrandId = 2 , ColorId = 2 , DailyPrice = 5750 , Description = "Sıfır Model Otomatik Vites" , ModelYear = 2015 }
            };
            
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
            _cars.Remove(carToDelete);
            
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=> c.CarId==Id).ToList();  
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
