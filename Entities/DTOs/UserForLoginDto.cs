using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class OnayKoduKayitDto : IDto
    {
        public int Fk_Iletisim_Tip { get; set; }
        public string Hesap { get; set; }
        public int Onay_Kodu { get; set; }
    }
    public class OnayKoduSendDto : IDto
    {
        public string Hesap { get; set; }
    }
    public class OnayKoduDto : IDto
    {
        public string Hesap { get; set; }
        public int Onay_Kodu_Hatali_Giris { get; set; }
        public int Onay_Kodu { get; set; }
    }
}
