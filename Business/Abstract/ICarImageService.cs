using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImages carImage);
        IResult Update(CarImages carImage);
        IResult Delete(CarImages carImage);
        IDataResult<List<CarImages>> GetAll(Expression<Func<CarImages, bool>> filter = null);
        IDataResult<List<CarImages>> GetImagesByCarId(int carId);
        IDataResult<CarImages> Get(int id);
    }
}
