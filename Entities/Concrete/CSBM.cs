using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class CSBM :  IEntity
    {
        public int CSBM_KODU { get; set; }
        public string CSBM_ADI { get; set; }
        public Nullable<int> MAHALLE_KODU { get; set; }
        public string CSBM_TIP { get; set; }
    }
}
