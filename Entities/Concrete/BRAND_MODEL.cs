using Core.Entities;
using Core.Entities.Concrete;
using System;


namespace Entities.Concrete
{
    public partial class BRAND_MODEL: EntityBase<int>, IEntity
    {       

        public int FK_BRAND_ID { get; set; }

        public int FK_MODEL_ID { get; set; }

        public virtual BRAND BRAND { get; set; }

        public virtual MODEL MODEL { get; set; }
    }
}
