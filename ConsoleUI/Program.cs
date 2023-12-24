using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colorManager.GetById(2))
            //{
            //    Console.WriteLine(color.Name);
            //}

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAllCarsByColorId(1))
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName);
            }

            
        }



        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAllCarsByBrandId(1))   //carManager daki tüm ürünleri getir.
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
