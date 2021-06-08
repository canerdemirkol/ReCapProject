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
    public class MahalleManager : IMahalleService
    {
        private IMahalleRepository _mahallelerRepository;
        public MahalleManager(IMahalleRepository mahallelerRepository)
        {
            _mahallelerRepository = mahallelerRepository;
        }
        [CacheAspect(1440)]
        public IDataResult<List<MAHALLE>> mahalleListele(int ilceKodu)
        {
            return new SuccessDataResult<List<MAHALLE>>(_mahallelerRepository.mahalleListele(ilceKodu));
        }
    }
}
