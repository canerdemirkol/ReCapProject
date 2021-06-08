namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    //[Table("TRACTIONS")]
    public partial class TRACTION : EntityBase<int>, IEntity
    {
        public TRACTION()
        {
            CARS_DETAILS = new HashSet<CAR_DETAIL>();
        }

        //[Required]
        //[StringLength(250)]
        public string NAME { get; set; }

        public virtual ICollection<CAR_DETAIL> CARS_DETAILS { get; set; }
    }
}
