using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class ADRES_TIP:EntityBase<int>,IEntity
    {
        public string TIP_ADI { get; set; }
    }
}
