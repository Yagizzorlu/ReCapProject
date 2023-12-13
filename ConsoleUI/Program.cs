using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())   //carManager daki tüm ürünleri getir.
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
