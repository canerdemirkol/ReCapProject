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
    public class MahallelerRepository : EfEntityRepositoryBase<MAHALLE, ProjectDbContext>, IMahalleRepository
    {
        public MahallelerRepository(ProjectDbContext context) : base(context)
        {

        }

        public List<MAHALLE> mahalleListele(int ilceKodu)
        {
            return GetList(x => x.ILCE_KODU == ilceKodu).ToList();
        }
    }
}
