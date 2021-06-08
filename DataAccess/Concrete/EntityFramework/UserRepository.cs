using Core.DataAccess.EntityFreamwork;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserRepository : EfEntityRepositoryBase<User, ProjectDbContext>, IUserRepository
    {
        public UserRepository(ProjectDbContext context) : base(context)
        {
        }

        public List<OperationClaim> GetClaims(int userId)
        {
            var result = from user in Context.Users
                          join userOperationClaim in Context.UserOperationClaims on user.ID equals userOperationClaim.UserId
                          join operationClaim in Context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.ID
                          where user.ID == userId
                          select new OperationClaim { ID = operationClaim.ID, Name = operationClaim.Name };
            return result.ToList();
        }

       
    }
}
