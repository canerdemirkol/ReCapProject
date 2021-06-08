namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class CAR_ENGINE_PERFORMANCE : EntityBase<int>, IEntity
    {
        public int FK_CAR_ID { get; set; }

        public int? CYLINDERS { get; set; }

        public int? ENGINE_CAPACITY { get; set; }

        //[StringLength(50)]
        public string MAX_POWER { get; set; }

        //[StringLength(50)]
        public string MAX_TORQUE { get; set; }

        //[StringLength(50)]
        public string SPEED_LIMIT { get; set; }

        public decimal? ACCELERATION { get; set; }

        public virtual CAR CAR { get; set; }
    }
}
