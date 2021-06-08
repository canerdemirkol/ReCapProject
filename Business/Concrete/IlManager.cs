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
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using DataAccess.Concrete.RepoDb.DbConnection.SqlDatabases;
using Core.DataAccess.RepoDb;
using System.Data;
using System.Data.SqlClient;
using Entities.DTOs;
using RepoDb;
using AutoMapper;

namespace Business.Concrete
{

    public class IlManager : IIlService
    {
        private IIlRepository _iIllerRepository;
        private readonly IMapper _mapper;
        public QueryableRepositoryBase<IlDto, ReCapDbConnectionFactory> ilRepo = new QueryableRepositoryBase<IlDto, ReCapDbConnectionFactory>();

        public IlManager(IIlRepository iIllerRepository,IMapper mapper)
        {
            _iIllerRepository = iIllerRepository;
            _mapper = mapper;
        }

        [CacheAspect(1440)]
        public IDataResult<List<IlDto>> ilListele()
        {


            //string commandText = @"select convert(int,IL_KODU)as IL_KODU ,CONVERT(nvarchar,IL_ADI) as IL_ADI from ILLER";
            //var listResult = ilRepo.GetByExecuteTextQuery(commandText, null);
            string postListProcNameText = @"[dbo].[prc_GET_Il]";
            //var postListResult = ilRepo.GetByExecuteStoredProcedureQuery(postListProcNameText, new { ilKodu = 33 });
            var postListResult = ilRepo.GetByExecuteStoredProcedureQuery(postListProcNameText, null).ToList();



            return new SuccessDataResult<List<IlDto>>(postListResult);




            //return new SuccessDataResult<List<IlDto>>(_mapper.Map<List<IlDto>>(_iIllerRepository.ilListele()));
        }
    }
}
