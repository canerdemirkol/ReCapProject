namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;


    public partial class CAR_SPECIFICATION: EntityBase<int>, IEntity
    {

        public int FK_CAR_ID { get; set; }

        public int FK_SECURITY_ID { get; set; }

        public int FK_EXTERNAL_HARDWARE_ID { get; set; }

        public int FK_INTERNAL_EQUIPMENT_ID { get; set; }

        public int FK_MULTIMEDIA_ID { get; set; }

        public virtual CAR CAR { get; set; }

        public virtual EXTERNAL_HARDWARE EXTERNAL_HARDWARES { get; set; }

        public virtual INTERNAL_EQUIPMENT INTERNAL_EQUIPMENTS { get; set; }

        public virtual MULTIMEDIA MULTIMEDIA { get; set; }

        public virtual CAR_SECURITY CAR_SECURITY { get; set; }
    }
}
