using Core.Entities.Concrete;
using Core.Utilities.Map.Google;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMapKeyService
    {
        IDataResult<KonumdanAdresDetay> konumdanAdresGetir(string lat, string lng);
    }
}
