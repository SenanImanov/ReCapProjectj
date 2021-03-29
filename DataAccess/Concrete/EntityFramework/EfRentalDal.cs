using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rentals, ReCapProjectcontext>, IRentalsDal
    {
        public List<RentalDetailDto> GetCarRentalDetails(Expression<Func<Rentals, bool>> filter = null)
        {
            using (ReCapProjectcontext context = new ReCapProjectcontext())
            {
                var result = from rnt in filter is null ? context.Rentals : context.Rentals.Where(filter)

                             join Car in context.Car on rnt.CarId equals  Car.CarId
                             join cl in context.Color on Car.ColorId equals cl.ColorId
                             join brd in context.Brand on Car.BrandId equals brd.BrandId
                             join cs in context.Customer on rnt.CustomerId equals cs.UsersId
                             join usr in context.Users on cs.UsersId equals usr.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = rnt.CarId,
                                 CustomerName = usr.FirstName,
                                 CustomerLastName = usr.LastName,
                                 CustomerCompanyName = cs.CompanyName,
                                 CarName = Car.Description,
                                 BrandName = brd.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = Car.DailyPrice,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate
                             };

                return result.ToList();
            }
        }

        public Rentals GetCarRentalDetails(Func<Rentals, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
