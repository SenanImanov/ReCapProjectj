using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        public IResult Add(CarImages carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImages carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImages> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImages>> GetAll(Expression<Func<CarImages, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImages carImage)
        {
            throw new NotImplementedException();
        }
    }
}
