using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class AdresTipRepository : EfEntityRepositoryBase<ADRES_TIP, ProjectDbContext>, IAdresTipRepository
    {
        public AdresTipRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
