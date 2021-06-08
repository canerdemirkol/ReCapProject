using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Core.Utilities.Results.Concrete.Succes;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class KurumSmsManager : IKurumSmsService
    {
        private IKurumSmsRepository _kurumSmsRepository;

        public KurumSmsManager(IKurumSmsRepository kurumSmsRepository)
        {
            _kurumSmsRepository = kurumSmsRepository;
        }

        public IDataResult<KURUM_SMS> Get(int kurumId)
        {
            return new SuccessDataResult<KURUM_SMS>(_kurumSmsRepository.GetAsNoTrack(x => x.KURUM_ID == kurumId));
        }
    }
}
