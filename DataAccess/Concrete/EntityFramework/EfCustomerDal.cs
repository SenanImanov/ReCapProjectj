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
   public class EfCustomerDal: EfEntityRepositoryBase<Customer, ReCapProjectcontext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapProjectcontext context = new ReCapProjectcontext())
            {
                var result = from cs in filter is null ? context.Customer  : context.Customer.Where(filter)
                             join usr in context.Users on cs.UsersId equals usr.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = cs.UsersId ,
                                 UserId = usr.UserId,
                                 UserName = usr.FirstName,
                                 UserLastName = usr.LastName,
                                 CompanyName = cs.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
