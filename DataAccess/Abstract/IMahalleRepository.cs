using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFreamwork;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMahalleRepository : IEntityRepository<MAHALLE>
    {

        List<MAHALLE> mahalleListele(int ilceKodu);
        
    }
}
