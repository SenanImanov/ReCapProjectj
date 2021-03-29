using Business.Abstract;
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
            ICarService carManager = new CarManager(new EfCarDal());
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            IColorService colorManager = new ColorManager(new EfColorDal());
            IUsersService user = new UserManager(new EfUsersDal());
            //CarTest(carManager);
            //BrandTest(brandManager);
            //ColorTest(colorManager);
            Users user1 = new Users { FirstName = "Senan", LastName = "Imanov", Email = "senanimanov@", Password = "3265" };
            user.Add(user1);
            var result2 = user.GetAll();
            foreach (var item in result2.Data)
            {
                Console.WriteLine(item.FirstName + item.LastName);
            }


            Console.WriteLine("------join işlemi sonucu gelen değerler----------");
            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", car.BrandName, car.DailyPrice, car.ColorName);

            }







        }
    }
}