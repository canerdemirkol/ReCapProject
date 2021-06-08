﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IKurumSmsService
    {
        IDataResult<KURUM_SMS> Get(int kurumId);
    }
}
