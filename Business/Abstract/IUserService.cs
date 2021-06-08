using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(int userId);
        void Add(User user);
        User GetByMail(string email);

        Task<IDataResult<BaseAuthUser>> Authenticate(string email, string password);
        IDataResult<List<User>> GetList();
    }
}
