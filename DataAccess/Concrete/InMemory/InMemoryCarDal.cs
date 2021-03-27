using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Color> _colors;
        List<Brand> _brands;
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1, BrandId=2, ColorId=3, ModelYear=2003, DailyPrice=250, Description="Ekonomik araç"},
                new Car {Id=2, BrandId=3, ColorId=3, ModelYear=2010, DailyPrice=950, Description="Prestij araç"},
                new Car {Id=3, BrandId=1, ColorId=1, ModelYear=2014, DailyPrice=1000, Description="Lüks araç"},
                new Car {Id=4, BrandId=3, ColorId=2, ModelYear=2008, DailyPrice=450, Description="Konfor araç"},
                new Car {Id=5, BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=1050, Description="Premium araç"}
            };

            _colors = new List<Color>
            {
                new Color{ColorId=1, ColorName="Siyah"},
                new Color{ColorId=2, ColorName="Beyaz"},
                new Color{ColorId=3, ColorName="Gri"}
            };

            _brands = new List<Brand> 
            { 
                new Brand{BrandId=1, BrandName="Volvo"},
                new Brand{BrandId=2, BrandName="Renault"},
                new Brand{BrandId=3, BrandName="Ford"}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);

            Console.WriteLine("Eklendi!");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);

            Console.WriteLine("Silindi!");
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
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<CarDetailDto> GetCarByBrandDetails(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarByColorDetails(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

            Console.WriteLine("Güncellendi!");
        }
    }
}
