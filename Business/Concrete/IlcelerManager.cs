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
using AutoMapper;
using Core.Aspects.Autofac.Caching;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Aspects.Autofac.Logging;


namespace Business.Concrete
{
    public class IlcelerManager : IIlceService
    {
        private IIlceRepository _iIlcelerRepository;
        private readonly IMapper _mapper;
        public IlcelerManager(IIlceRepository iIlcelerRepository, IMapper mapper)
        {
            _iIlcelerRepository = iIlcelerRepository;
            _mapper = mapper;
        }

        [CacheAspect(1440)]
        //[LogAspect(typeof(FileLogger))]
        public IDataResult<List<IlceDto>> ilceListele(int ilKodu)
        {   
            return new SuccessDataResult<List<IlceDto>>(_mapper.Map<List<IlceDto>>(_iIlcelerRepository.ilceListele(ilKodu)));
        }

    }
}
