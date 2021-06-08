using Core.DataAccess.EntityFreamwork;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class UsersAllowedToUseAPIRepository : EfEntityRepositoryBase<UserAllowedToUseAPI, ProjectDbContext>, IUsersAllowedToUseAPIRepository
    {
        public UsersAllowedToUseAPIRepository(ProjectDbContext context) : base(context)
        {
        }

    }
}
