using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class SISTEM_ONAY_KOD_KONTROL : EntityBase<int>, IEntity
    {
        public int FK_ILETISIM_TIP { get; set; }
        public string HESAP { get; set; }
        public int ONAY_KODU { get; set; }
        public int ONAY_KODU_HATALI_GIRIS { get; set; }
        public bool ONAY_KODU_KONTROL { get; set; }
        public System.DateTime KAYIT_TARIH { get; set; }
        public Nullable<System.DateTime> GIRIS_TARIH { get; set; }
    }
}
