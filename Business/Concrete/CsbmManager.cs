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
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CsbmManager : ICsbmService
    {
        private ICsbmRepository _csbmRepository;
        public CsbmManager(ICsbmRepository csbmRepository)
        {
            _csbmRepository = csbmRepository;
        }
        [CacheAspect(1440)]
        public IDataResult<List<CSBM>> csbmListele(int mahalleKodu)
        {
            return new SuccessDataResult<List<CSBM>>(_csbmRepository.csbmListele(mahalleKodu));
        }
    }
}
