using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class KurumSmsRepository : EfEntityRepositoryBase<KURUM_SMS, ProjectDbContext>, IKurumSmsRepository
    {
        public KurumSmsRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
