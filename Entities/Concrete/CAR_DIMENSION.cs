namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class CAR_DIMENSION: EntityBase<int>, IEntity
    {

        public int FK_CAR_ID { get; set; }

        public int? FK_TIRE_SIZE_ID { get; set; }

        public int? NUMBER_OF_SEATS { get; set; }

        public int? LENGTH { get; set; }

        public int? WIDTH { get; set; }

        public int? HEIGHT { get; set; }

        public int? NET_WEIGHT { get; set; }

        public int? CAPACITY { get; set; }

        public int? LUGGAGE_CAPACITY { get; set; }

        public virtual CAR CAR { get; set; }

        public virtual TIRE_SIZE TIRE_SIZES { get; set; }
    }
}
