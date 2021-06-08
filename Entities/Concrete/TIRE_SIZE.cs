namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class TIRE_SIZE : EntityBase<int>, IEntity
    {
        public TIRE_SIZE()
        {
            CARS_DIMENSIONS = new HashSet<CAR_DIMENSION>();
        }

        //[StringLength(50)]
        public string SIZE { get; set; }

        public virtual ICollection<CAR_DIMENSION> CARS_DIMENSIONS { get; set; }
    }
}
