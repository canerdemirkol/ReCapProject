using Business.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using Entities.DTOs;
using Core.Utilities.Toolkit;
using Business.Adapters.SmsService.NetGSM;
using Core.Utilities.Results.Concrete.Errors;
using Business.Constants;

namespace Business.Concrete
{

    public class NetGsmSistemOnayKodManager : INetGsmSistemOnayKodService
    {
        private ISistemOnayKodKontrolService _sistemOnayKodKontrolService;
        private IKurumSmsService _kurumSmsService;
        private INetGsmSmsService _netGsmSmsService;

        public NetGsmSistemOnayKodManager(INetGsmSmsService netGsmSmsService, ISistemOnayKodKontrolService sistemOnayKodKontrolService, IKurumSmsService kurumSmsService)
        {
            _sistemOnayKodKontrolService = sistemOnayKodKontrolService;
            _kurumSmsService = kurumSmsService;
            _netGsmSmsService = netGsmSmsService;
        }

        public IResult GsmOnayKoduKayit(string Hesap)
        {
            var generedPassword = RandomPassword.RandomNumberGenerator();
            string mesaj = "";
            mesaj += @"Sisteme giriş yapmak için;\n";
            mesaj += @"Gsm doğrulama kodunu giriniz.\n";
            mesaj += @"GSM Doğrulama Kodu: " + generedPassword;
            mesaj += @"\n" + DateTime.Now.ToString();

            var gsm = new[] { Hesap };

            var kurumSmsBilgisi = _kurumSmsService.Get(-1).Data;
            if (kurumSmsBilgisi==null)
            {
                return  new ErrorResult(Messages.DefaultSmsPackageNotFound);
            }
            else
            {
                var smsGonderimResult = _netGsmSmsService.Send_1N(kurumSmsBilgisi.USERNAME,
                                                       kurumSmsBilgisi.PASSWORD,
                                                       kurumSmsBilgisi.COMPANY,
                                                       kurumSmsBilgisi.HEADER,
                                                       mesaj,
                                                       gsm,
                                                       kurumSmsBilgisi.BAYI_KODU,
                                                       "",
                                                       "");

                return _sistemOnayKodKontrolService.OnayKoduKayit(new OnayKoduKayitDto { Hesap = Hesap, Onay_Kodu = generedPassword, Fk_Iletisim_Tip = 1 });
            }

        }

    }
}
