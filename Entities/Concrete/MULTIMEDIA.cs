namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    //[Table("MULTIMEDIAS")]
    public partial class MULTIMEDIA : EntityBase<int>, IEntity
    {
        public MULTIMEDIA()
        {
            CAR_SPECIFICATIONS = new HashSet<CAR_SPECIFICATION>();
        }

        //[StringLength(250)]
        public string NAME { get; set; }

        public virtual ICollection<CAR_SPECIFICATION> CAR_SPECIFICATIONS { get; set; }
    }
}
