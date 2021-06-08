namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    //[Table("SEGMENTS")]
    public partial class SEGMENT: EntityBase<int>, IEntity
    {
        public SEGMENT()
        {
            MODEL_SEGMENTS = new HashSet<MODEL_SEGMENT>();
        }


        //[StringLength(50)]
        public string NAME { get; set; }

        public virtual ICollection<MODEL_SEGMENT> MODEL_SEGMENTS { get; set; }
    }
}
