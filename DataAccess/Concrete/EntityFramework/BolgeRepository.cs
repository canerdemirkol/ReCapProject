using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class BolgeRepository : EfEntityRepositoryBase<BOLGE, ProjectDbContext>, IBolgeRepository
    {
        public BolgeRepository(ProjectDbContext context) : base(context)
        {

        }
    }
}
