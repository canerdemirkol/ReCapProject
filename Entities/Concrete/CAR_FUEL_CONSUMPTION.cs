namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class CAR_FUEL_CONSUMPTION : EntityBase<int>, IEntity
    {
        public int FK_CAR_ID { get; set; }

        //[StringLength(50)]
        public string FUEL_TYPE { get; set; }

        public decimal? INNER_CITY { get; set; }

        public decimal? OUT_OF_TOWN { get; set; }

        public decimal? AVERAGE { get; set; }

        public int? FUEL_TANK_VOLUME { get; set; }

        public virtual CAR CAR { get; set; }
    }
}
