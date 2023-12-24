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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())   //carManager daki tüm ürünleri getir.
            {
                Console.WriteLine(car.Description);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());
        }
    }
}
