using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface INetGsmSistemOnayKodService
    {
        IResult GsmOnayKoduKayit(string Hesap);
    }
}
