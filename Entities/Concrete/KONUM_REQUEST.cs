using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class KONUM_REQUEST : EntityBase<int>, IEntity
    {
        public string IL { get; set; }
        public string ILCE { get; set; }
        public string MAHALLE { get; set; }
        public string CSBM { get; set; }
        public string BINA_ADI { get; set; }
        public string BINA_NO { get; set; }
        public string MEVKI { get; set; }
        public string LAT_LNG { get; set; }
        public string LAT { get; set; }
        public string LNG { get; set; }
    }
}
