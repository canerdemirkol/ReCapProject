namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class EXTERNAL_HARDWARE : EntityBase<int>, IEntity
    {
        public EXTERNAL_HARDWARE()
        {
            CAR_SPECIFICATIONS = new HashSet<CAR_SPECIFICATION>();
        }

        //[StringLength(250)]
        public string NAME { get; set; }

        public virtual ICollection<CAR_SPECIFICATION> CAR_SPECIFICATIONS { get; set; }
    }
}
