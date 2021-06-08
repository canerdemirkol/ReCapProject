using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class IlceRepository : EfEntityRepositoryBase<ILCE, ProjectDbContext>, IIlceRepository
    {
        public IlceRepository(ProjectDbContext context) : base(context)
        {

        }
       
        public List<ILCE> ilceListele(int ilKodu)
        {
            return GetList(p => p.IL_KODU == ilKodu).ToList();
        }
    }
}
