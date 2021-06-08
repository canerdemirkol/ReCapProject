namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class CAR_STATUS: EntityBase<int>, IEntity
    {
        public CAR_STATUS()
        {
            CARS_DETAILS = new HashSet<CAR_DETAIL>();
        }

        //[Required]
        //[StringLength(250)]
        public string NAME { get; set; }

        public virtual ICollection<CAR_DETAIL> CARS_DETAILS { get; set; }
    }
}
