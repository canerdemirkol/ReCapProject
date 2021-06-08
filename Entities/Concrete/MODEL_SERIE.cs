namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class MODEL_SERIE: EntityBase<int>, IEntity
    {
        public int FK_MODEL_ID { get; set; }

        //[StringLength(250)]
        public string NAME { get; set; }

        public virtual MODEL MODEL { get; set; }
    }
}
