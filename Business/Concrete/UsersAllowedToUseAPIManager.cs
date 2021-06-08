using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Errors;
using Core.Utilities.Results.Concrete.Succes;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UsersAllowedToUseAPIManager : IUsersAllowedToUseAPIService
    {

        IUsersAllowedToUseAPIRepository _usersAllowedToUseAPIRepository;

        public UsersAllowedToUseAPIManager(IUsersAllowedToUseAPIRepository usersAllowedToUseAPIRepository)
        {
            _usersAllowedToUseAPIRepository = usersAllowedToUseAPIRepository;
        }

        public IResult UserAllowedToUseEmailExists(string email)
        {

            if (_usersAllowedToUseAPIRepository.Get(prm => prm.Email == email && prm.Status == true) == null)
            {
                return new ErrorResult(Messages.UserNotAllowedToUseAPI);
            }
            return new SuccessResult();
        }
    }
   
}
