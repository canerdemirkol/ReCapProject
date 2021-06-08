using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class MAHALLE:IEntity
    {
        public int MAHALLE_KODU { get; set; }
        public string MAHALLE_ADI { get; set; }
        public Nullable<int> ILCE_KODU { get; set; }
    }
}
