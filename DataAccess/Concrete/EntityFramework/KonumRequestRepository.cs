using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class KonumRequestRepository : EfEntityRepositoryBase<KONUM_REQUEST, ProjectDbContext>, IKonumRequestRepository
    {
        public KonumRequestRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
