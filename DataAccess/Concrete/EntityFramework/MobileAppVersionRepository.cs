using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MobileAppVersionRepository : EfEntityRepositoryBase<MOBILE_APP_VERSION, ProjectDbContext>, IMobileAppVersionRepository
    {
        public MobileAppVersionRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
