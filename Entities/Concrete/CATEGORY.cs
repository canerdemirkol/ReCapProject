namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    //[Table("CATEGORIES")]
    public partial class CATEGORY : EntityBase<int>, IEntity
    {
        public CATEGORY()
        {
            CARS_DETAILS = new HashSet<CAR_DETAIL>();
        }


        //[StringLength(250)]
        public string NAME { get; set; }

        public bool STATUS { get; set; }

        public virtual ICollection<CAR_DETAIL> CARS_DETAILS { get; set; }
    }
}
