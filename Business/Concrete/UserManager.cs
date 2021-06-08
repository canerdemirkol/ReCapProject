using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Errors;
using Core.Utilities.Results.Concrete.Succes;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserManager(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<OperationClaim> GetClaims(int userId)
        {
            return _userRepository.GetClaims(userId);
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
            _userRepository.SaveChanges();
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userRepository.GetList().ToList());
        }


        public async Task<IDataResult<BaseAuthUser>> Authenticate(string email, string password)
        {
            var user = await Task.Run(() =>_userRepository.GetList().SingleOrDefault(x => x.Email == email));

            // return null if user not found
            if (user == null)
                return new ErrorDataResult<BaseAuthUser>(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<BaseAuthUser>(Messages.PasswordError);
            }

            return new SuccessDataResult<BaseAuthUser>(_mapper.Map<BaseAuthUser>(user), Messages.SuccessfulLogin);
        }
    }
}
