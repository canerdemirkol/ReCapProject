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

namespace Business.Concrete
{
    public class KonumRequestManager : IKonumRequestService
    {
        private IKonumRequestRepository _konumRequestRepository;
        public KonumRequestManager(IKonumRequestRepository konumRequestRepository)
        {
            _konumRequestRepository = konumRequestRepository;
        }


    }
}
