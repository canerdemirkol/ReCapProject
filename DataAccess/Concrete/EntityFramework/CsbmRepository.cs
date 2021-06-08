using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CsbmRepository : EfEntityRepositoryBase<CSBM, ProjectDbContext>, ICsbmRepository
    {
        public CsbmRepository(ProjectDbContext context) : base(context)
        {

        }

        public List<CSBM> csbmListele(int mahalleKodu)
        {
            return GetList(p => p.MAHALLE_KODU == mahalleKodu).ToList();
        }
    }
}
