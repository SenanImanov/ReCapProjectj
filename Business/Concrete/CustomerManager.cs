using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerdal)
        {
            _customerDal = customerdal;
        }

        public IResult Add(Customer customer)
        {
            if(customer.UsersId !=0)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }

            return new ErrorResult(Messages.CustomerNotAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.UsersId != 0)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }

            return new ErrorResult(Messages.CustomerNotDeleted);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
