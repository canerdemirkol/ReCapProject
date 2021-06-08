namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class MODEL_SEGMENT : EntityBase<int>, IEntity
    {

        public int FK_MODEL_ID { get; set; }

        public int FK_SEGMENT_ID { get; set; }

        public virtual MODEL MODEL { get; set; }

        public virtual SEGMENT SEGMENT { get; set; }
    }
}
