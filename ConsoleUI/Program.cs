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

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAllCarsByColorId(2))
            //{
            //    Console.WriteLine(car.Description);
            //}

            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = carManager.GetAllCarDetailDtos();

            if (result.Success == true)
            {
                foreach (var car in carManager.GetAllCarDetailDtos().Data)
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }



        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAllCarsByBrandId(1))   //carManager daki tüm ürünleri getir.
        //    {
        //        Console.WriteLine(car.Description);
        //    }
        //}
    }
}
