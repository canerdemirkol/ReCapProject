using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFreamwork;
using Core.Utilities.Map.Google;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMapKeyRepository : IEntityRepository<MAP_KEY>
    {
        KonumdanAdresDetay konumdanAdresGetir(string lat, string lng);
    }
}
