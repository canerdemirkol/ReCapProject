using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFreamwork;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICsbmRepository : IEntityRepository<CSBM>
    { 
        List<CSBM> csbmListele(int mahalleKodu);
    }
}
