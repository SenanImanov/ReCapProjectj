using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalsDal : InEntityRepository<Rentals>
    {
        Rentals GetCarRentalDetails(Func<Rentals, bool> p);
    }

}
