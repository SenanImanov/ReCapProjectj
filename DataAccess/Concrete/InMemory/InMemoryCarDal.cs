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
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ CarId = 1, CategoryId = 1 ,BrandId = "BMW", ColorId = "black", DailyPrice = 333 , ModelYear ="1997" , },
                new Car{ CarId = 2, CategoryId = 1, BrandId = "MERSEDES", ColorId = "yellow", DailyPrice = 323 , ModelYear ="1993" , },
                new Car{ CarId = 3,CategoryId = 1,  BrandId = "OPEL", ColorId = "blue", DailyPrice = 223 , ModelYear ="1995" , },
                new Car{ CarId = 4,CategoryId = 1,  BrandId = "FERRARI", ColorId = "red", DailyPrice = 324 , ModelYear ="1996" , },
                new Car{ CarId = 5,CategoryId = 1,  BrandId = "KIA", ColorId = "green", DailyPrice = 33 , ModelYear ="1998" , }


            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
             Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get()
        {
            throw new NotImplementedException();
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

        public List<Car> GetById(int categoryId)
        {
           return _cars.Where(c => c.CategoryId == categoryId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.CategoryId = car.CategoryId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;



            
        }
    }
}
