using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class ILCE :  IEntity
    {
        public int ILCE_KODU { get; set; }
        public int IL_KODU { get; set; }
        public string ILCE_ADI { get; set; }
        public bool DURUM { get; set; }
    }
}
