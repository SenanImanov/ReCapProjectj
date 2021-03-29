using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUsersService
    {

        IUsersDal _usersDal;
        public  UserManager (IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(Users users)
        {
            if (users.FirstName == "" || users.LastName == "")
            {
                return new ErrorResult(Messages.FirstNameLastNameInvalid);
            }

            _usersDal.Add(users);
            return new SuccessResult(Messages.UsersAdded);
        }

        public IResult Delete(Users users)
        {
            if (users.UserId != 0)
            {
                _usersDal.Delete(users);
                return new SuccessResult(Messages.UsersDeleted);
            }
            else
            {
                return new ErrorResult(Messages.UsersNotDeleted);
            }
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(), Messages.UsersListed);
        }

        public IResult Update(Users users)
        {
            _usersDal.Update(users);
            return new SuccessResult(Messages.UsersUpdated);
        }
    }
}
