using Core.Entities;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{

    public partial class BRAND: EntityBase<int>,IEntity
    {
      
        public BRAND()
        {
            BRANDS_MODELS = new HashSet<BRAND_MODEL>();
            CARS_DETAILS = new HashSet<CAR_DETAIL>();
        }       

        //[StringLength(250)]
        public string NAME { get; set; }       

        public bool STATUS { get; set; }     
        public virtual ICollection<BRAND_MODEL> BRANDS_MODELS { get; set; }

        public virtual ICollection<CAR_DETAIL> CARS_DETAILS { get; set; }
    }


}
