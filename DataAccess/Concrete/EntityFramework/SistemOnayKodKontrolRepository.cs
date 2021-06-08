using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class SistemOnayKodKontrolRepository : EfEntityRepositoryBase<SISTEM_ONAY_KOD_KONTROL, ProjectDbContext>, ISistemOnayKodKontrolRepository
    {
        public SistemOnayKodKontrolRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
