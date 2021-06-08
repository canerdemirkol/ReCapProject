using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Succes;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace Business.Concrete
{
    public class SistemOnayKodKontrolManager : ISistemOnayKodKontrolService
    {
        private ISistemOnayKodKontrolRepository _sistemOnayKodKontrolRepository;

        public SistemOnayKodKontrolManager(ISistemOnayKodKontrolRepository sistemOnayKodKontrolRepository)
        {
            _sistemOnayKodKontrolRepository = sistemOnayKodKontrolRepository;
        }

        public IResult OnayKoduKayit(OnayKoduKayitDto onayKoduKayitDto)
        {
            var sistemOnayKoduKayit = new SISTEM_ONAY_KOD_KONTROL
            {
                FK_ILETISIM_TIP = onayKoduKayitDto.Fk_Iletisim_Tip,
                HESAP = onayKoduKayitDto.Hesap,
                ONAY_KODU = onayKoduKayitDto.Onay_Kodu,
                ONAY_KODU_HATALI_GIRIS = 0,
                KAYIT_TARIH = DateTime.Now

            };
            _sistemOnayKodKontrolRepository.Add(sistemOnayKoduKayit);
            _sistemOnayKodKontrolRepository.SaveChanges();
            return new SuccessResult();
        }
    }
}
