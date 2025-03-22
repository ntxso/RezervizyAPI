using BusinessWithSupplier.Abstract;
using BusinessWithSupplier.Constants;
using CleaningEntities;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCerated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            User userToCheck = _userService.GetByEmailOrIdentiyName(userForLoginDto.Email).Data;

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

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var user = new User
            {
                Email = userForRegisterDto.Email,
                IdentityName = userForRegisterDto.IdentityName,
                FirstName = userForRegisterDto.SupplierName,
                //PasswordHash = passwordHash,
                //PasswordSalt = passwordSalt,
                Status = true,
                LastName = userForRegisterDto.OwnerName,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                SupplierId = userForRegisterDto.SupplierId

            };
            if (UserExists(user.Email).Success && UserExists(user.IdentityName).Success)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _userService.Add(user);

                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }

            return new ErrorDataResult<User>(user, "Aynı isimde kullanıcı var!");


        }

        public IResult UserExists(string emailOrIdName)
        {
            var isThere = _userService.GetByEmailOrIdentiyName(emailOrIdName);
            if (isThere.Success)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
