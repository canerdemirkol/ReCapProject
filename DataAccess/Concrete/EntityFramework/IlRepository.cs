using Core.DataAccess.EntityFreamwork;
using Core.Entities;
using Core.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class IlRepository : EfEntityRepositoryBase<IL, ProjectDbContext>, IIlRepository
    {

        public IlRepository(ProjectDbContext context) : base(context)
        {
            
        }
        public List<IL> ilListele()
        {
            return GetList().ToList();
        }
    }
}
