using Core.DataAccess.EntityFreamwork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    public interface IIlRepository : IEntityRepository<IL>
    {
        List<IL> ilListele();
    }
}
