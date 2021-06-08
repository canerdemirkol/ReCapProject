using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Concrete
{
    public partial class CAR_IMAGE : EntityBase<int>, IEntity
    {
        public int FK_CAR_ID { get; set; }

        public string IMAGE_PATH { get; set; }

        public DateTime DATE_OF_REGISTRATION { get; set; }

        public virtual CAR CAR { get; set; }
    }


}
