namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    //[Table("MODELS")]
    public partial class MODEL : EntityBase<int>, IEntity
    {
        public MODEL()
        {
            BRANDS_MODELS = new HashSet<BRAND_MODEL>();
            CARS_DETAILS = new HashSet<CAR_DETAIL>();
            MODEL_SEGMENTS = new HashSet<MODEL_SEGMENT>();
            MODEL_SERIES = new HashSet<MODEL_SERIE>();
        }

        //[Required]
        //[StringLength(250)]
        public string NAME { get; set; }

        public DateTime DATE_OF_REGISTRATION { get; set; }

        public DateTime? DATE_OF_UPDATE { get; set; }

        public int? REGISTERED_USER_ID { get; set; }

        public int? UPDATED_USER_ID { get; set; }

        public bool STATUS { get; set; }

        public virtual ICollection<BRAND_MODEL> BRANDS_MODELS { get; set; }

        public virtual ICollection<CAR_DETAIL> CARS_DETAILS { get; set; }
        public virtual ICollection<MODEL_SEGMENT> MODEL_SEGMENTS { get; set; }
        public virtual ICollection<MODEL_SERIE> MODEL_SERIES { get; set; }
    }
}
