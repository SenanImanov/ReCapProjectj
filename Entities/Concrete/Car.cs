using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car: IEntity
    {
        public int CarId { get; set; }
        public string BrandId { get; set; }
        public string ColorId { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public int Description { get; set; }
        public int CategoryId { get; set; }
    }
}
