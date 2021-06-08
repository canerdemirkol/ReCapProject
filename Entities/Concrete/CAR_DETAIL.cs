namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;


    public partial class CAR_DETAIL : EntityBase<int>, IEntity
    {

        public int? FK_CAR_ID { get; set; }

        public int FK_BRAND_ID { get; set; }

        public int FK_MODEL_ID { get; set; }

        public int? FK_COLORS_ID { get; set; }

        public int? FK_CATEGORY_ID { get; set; }

        public int? FK_CASE_TYPE_ID { get; set; }

        public int? FK_CAR_STATUS_ID { get; set; }

        public int? FK_FUEL_ID { get; set; }

        public int? FK_GEAR_ID { get; set; }

        public int? FK_TRACTION_ID { get; set; }

        public double? KM { get; set; }

        public int? YEAR { get; set; }

        public decimal? PRICE { get; set; }

        public decimal? DALIY_PRICE { get; set; }        

        public virtual BRAND BRAND { get; set; }

        public virtual CAR_STATUS CAR_STATUS { get; set; }

        public virtual CAR CAR { get; set; }

        public virtual CASE_TYPE CASE_TYPES { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        public virtual COLOR COLOR { get; set; }

        public virtual FUEL FUEL { get; set; }

        public virtual GEAR GEAR { get; set; }

        public virtual MODEL MODEL { get; set; }

        public virtual TRACTION TRACTION { get; set; }
    }
}
