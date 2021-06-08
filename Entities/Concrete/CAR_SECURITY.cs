namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    //[Table("CAR_SECURITIES")]
    public partial class CAR_SECURITY: EntityBase<int>, IEntity
    {
        public CAR_SECURITY()
        {
            CAR_SPECIFICATIONS = new HashSet<CAR_SPECIFICATION>();
        }


        //[StringLength(250)]
        public string NAME { get; set; }
        public virtual ICollection<CAR_SPECIFICATION> CAR_SPECIFICATIONS { get; set; }
    }
}
