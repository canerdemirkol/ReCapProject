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
using Core.Entities.Concrete;
using Core.Utilities.Map.Google;

namespace Business.Concrete
{
    public class MapKeyManager : IMapKeyService
    {
        private IMapKeyRepository _mapKeyRepository;
        public MapKeyManager(IMapKeyRepository mapKeyRepository)
        {
            _mapKeyRepository = mapKeyRepository;
        }

        public IDataResult<KonumdanAdresDetay> konumdanAdresGetir(string lat, string lng)
        {
            return new SuccessDataResult<KonumdanAdresDetay>(_mapKeyRepository.konumdanAdresGetir(lat,lng));
        }
    }
}
