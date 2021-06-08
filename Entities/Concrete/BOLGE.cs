using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class BOLGE : EntityBase<int>, IEntity
    {
        public string BOLGE_ADI { get; set; }
        public bool DURUM { get; set; }
    }
}
