using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalsService
    {
        IRentalsDal _rentalsDal;
        public RentalManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }
        public IResult Add(Rentals rentals)
        {
            var result = CheckReturnDate(rentals.RentalsId);

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _rentalsDal.Add(rentals);
            return new SuccessResult(Messages.RentalsAdded);

        }

        public IResult CheckReturnDate(int rentalsId)
        {
            var result = _rentalsDal.GetCarRentalDetails(r => r.RentalsId == rentalsId && r.ReturnDate == null);

            if (result.RentalsId >0)
            {
                return new ErrorResult(Messages.RentalsAddedError);
            }
            return new SuccessResult(Messages.RentalsAdded);
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalsDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(), Messages.RentalListed);
        }

        public IResult Update(Rentals rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(Rentals rentals)
        {
            var result = _rentalsDal.GetAll(r => r.RentalsId == rentals.RentalsId);
            var updateRentals = result.LastOrDefault();

            if (updateRentals.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalsUpdateReturnDateError);
            }

            updateRentals.ReturnDate = rentals.ReturnDate;
            _rentalsDal.Update(updateRentals);
            return new SuccessResult(Messages.RentalsUpdateReturnDate);
        }
    }
}
