using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Errors;
using Core.Utilities.Results.Concrete.Succes;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUsersAllowedToUseAPIService _usersAllowedToUseAPIService;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUsersAllowedToUseAPIService usersAllowedToUseAPIService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _usersAllowedToUseAPIService = usersAllowedToUseAPIService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            IResult result = BusinessRules.Run(CheckIfUserAllowedToUseEmailExists(email));
            if (result == null)
            {
                if (CheckIfUserMail(email).Success)
                {
                    return new SuccessResult();
                }
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new ErrorResult(result.Message);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user.ID);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }



        private IResult CheckIfUserAllowedToUseEmailExists(string email)
        {
            return _usersAllowedToUseAPIService.UserAllowedToUseEmailExists(email);

        }


        private IResult CheckIfUserMail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
