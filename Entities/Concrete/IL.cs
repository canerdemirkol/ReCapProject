using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class IL :  IEntity
    {
        public int IL_KODU { get; set; }
        public string IL_ADI { get; set; }
        public bool DURUM { get; set; }
    }
}
