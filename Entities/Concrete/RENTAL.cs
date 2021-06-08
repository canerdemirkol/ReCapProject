using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public partial class RENTAL : EntityBase<int>, IEntity
    {

        public int FK_CAR_ID { get; set; }

        public int FK_CUSTOMER_ID { get; set; }
        public DateTime? RENT_DATE { get; set; }
        public DateTime? RETURN_DATE { get; set; }

        public DateTime DATE_OF_REGISTRATION { get; set; }

        public decimal? TOTAL_PRICE { get; set; }

        public virtual CAR CAR { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }
    }


}
