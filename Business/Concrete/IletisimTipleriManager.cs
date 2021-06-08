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
    public class IletisimTipManager : IIletisimTipService
    {
        private IIletisimTipRepository _iletisimTipleriRepository;
        public IletisimTipManager(IIletisimTipRepository iletisimTipleriRepository)
        {
            _iletisimTipleriRepository = iletisimTipleriRepository;
        }


    }
}
