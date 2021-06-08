using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
   //[Table("CARS")]
    public partial class CAR : EntityBase<int>,IEntity
    {
      public CAR()
        {
            
            CARS_DETAILS = new HashSet<CAR_DETAIL>();
            CARS_DIMENSIONS = new HashSet<CAR_DIMENSION>();
            CARS_ENGINE_PERFORMANCE = new HashSet<CAR_ENGINE_PERFORMANCE>();
            CARS_FUELS_CONSUMPTION = new HashSet<CAR_FUEL_CONSUMPTION>();
            CAR_IMAGES = new HashSet<CAR_IMAGE>();
            CAR_SPECIFICATIONS = new HashSet<CAR_SPECIFICATION>();
            RENTALS = new HashSet<RENTAL>();
        }      

        //[Required]
        //[StringLength(250)]
        public string NAME { get; set; }

        //[StringLength(500)]
        public string DESCRIPTION { get; set; }

        public DateTime DATE_OF_REGISTRATION { get; set; }

        public DateTime? DATE_OF_UPDATE { get; set; }

        public int? REGISTERED_USER_ID { get; set; }

        public int? UPDATED_USER_ID { get; set; }

        public bool STATUS { get; set; }
        public virtual ICollection<CAR_SPECIFICATION> CAR_SPECIFICATIONS { get; set; }

        public virtual ICollection<CAR_DETAIL> CARS_DETAILS { get; set; }

        public virtual ICollection<CAR_DIMENSION> CARS_DIMENSIONS { get; set; }

        public virtual ICollection<CAR_ENGINE_PERFORMANCE> CARS_ENGINE_PERFORMANCE { get; set; }

        public virtual ICollection<CAR_FUEL_CONSUMPTION> CARS_FUELS_CONSUMPTION { get; set; }
        public virtual ICollection<RENTAL> RENTALS { get; set; }

        public virtual ICollection<CAR_IMAGE> CAR_IMAGES { get; set; }
    }
}
