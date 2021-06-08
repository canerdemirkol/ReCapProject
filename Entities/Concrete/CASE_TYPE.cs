namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System.Collections.Generic;

    public partial class CASE_TYPE : EntityBase<int>, IEntity
    {
        public CASE_TYPE()
        {
            CARS_DETAILS = new HashSet<CAR_DETAIL>();
        }

        //[Required]
        //[StringLength(250)]
        public string NAME { get; set; }

        public virtual ICollection<CAR_DETAIL> CARS_DETAILS { get; set; }
    }
}
