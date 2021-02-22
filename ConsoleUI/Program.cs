using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            CarDetailTest();
            //AraçEkleme();


        }

        private static void AraçEkleme()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car() { BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 980, Description = "Premium araç" });
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetailDtos();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", car.Id, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            if (result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsByBrandId(3);

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }

            Console.WriteLine("-------------------------------------");

            var result1 = carManager.GetCarsByColorId(1);

            if (result1.Success==true)
            {
                foreach (var car in result1.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
        }
    }
}
