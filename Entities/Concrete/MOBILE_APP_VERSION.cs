using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class MOBILE_APP_VERSION:IEntity
    {
        public int version_id { get; set; }
        public string version { get; set; }
        public System.DateTime eklenme_tarihi { get; set; }
        public bool durum { get; set; }
    }
}
