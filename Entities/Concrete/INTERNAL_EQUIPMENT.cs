namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class INTERNAL_EQUIPMENT : EntityBase<int>, IEntity
    {
        public INTERNAL_EQUIPMENT()
        {
            CAR_SPECIFICATIONS = new HashSet<CAR_SPECIFICATION>();
        }
        //[StringLength(250)]
        public string NAME { get; set; }
        public virtual ICollection<CAR_SPECIFICATION> CAR_SPECIFICATIONS { get; set; }
    }
}
