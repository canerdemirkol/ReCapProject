namespace Entities.Concrete
{
    using Core.Entities;
    using Core.Entities.Concrete;
    using System;

    public class KURUM_SMS : EntityBase<int>, IEntity
    {
        public int KURUM_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string COMPANY { get; set; }
        public string HEADER { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public string LANGUAGE { get; set; }
        public Nullable<System.DateTime> STOP_DATE { get; set; }
        public string BAYI_KODU { get; set; }
        public bool DURUM { get; set; }
        public System.DateTime KAYIT_TARIHI { get; set; }
        public int ISLEM_YAPAN_USER { get; set; }
        public Nullable<System.DateTime> GUNCELLEME_TARIHI { get; set; }
        public Nullable<int> GUNCELLEYEN_ID { get; set; }
    }
}
