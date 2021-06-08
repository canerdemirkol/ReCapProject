namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;
    using System.Collections.Generic;

    public partial class ENGINE_CAPACITIE : EntityBase<int>, IEntity
    {
        //[Required]
        //[StringLength(250)]
        public string NAME { get; set; }
    }
}
