using BusinessWithSupplier.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Result;
using DACleaning.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void AddUserOperationClaim(User user, int claimId)
        {
            _userDal.AddUserOperationClaim(user, claimId);
        }

        public OperationClaim GetOperationClaim(string claimName)
        {
            return _userDal.GetOperationClaimByName(claimName);
        }

        public IDataResult<User> GetByEmailOrIdentiyName(string mailOrIdName)
        {
            User user = _userDal.Get(u => u.Email == mailOrIdName);
            if (user == null)
                user = _userDal.Get(p => p.IdentityName == mailOrIdName);
            if (user == null)
            {
                return new ErrorDataResult<User>(user, "Bu mail adresi kayıtlı değil.");
            }
            else
            {
                return new SuccessDataResult<User>(user, "Kullanıcı mevcut");
            }
        }
        public IList<User> GetUsers(string role = "")
        {
            if (role == "")
            {
                return _userDal.GetList();
            }
            return _userDal.GetUsersFromRole(role);
        }
        public User GetUserById(int id)
        {
            return _userDal.Get(p => p.Id == id);
        }
        public IResult ChangePassword(User user, string newPasword)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(newPasword, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            try
            {
                _userDal.Update(user);
                return new SuccessResult("Şifre başarıyla değiştirildi");
            }
            catch (Exception err)
            {
                return new ErrorResult("Hata oluştu: " + err.Message);
            }
        }

        public IResult ChangeIdentityName(User user)
        {
            if (_userDal.Get(p => p.IdentityName == user.IdentityName) == null)
            {
                _userDal.Update(user);
                return new SuccessResult("Kullanıcı adı başarıyla değiştirildi");
            }
            else
            {
                return new ErrorResult(user.IdentityName + " mevcut. Başka deneyin.");
            }
        }
        public IResult ChangeSupplierId(User user, int supplierId)
        {
            try
            {
                user.SupplierId = supplierId;
                _userDal.Update(user);
                return new SuccessResult("Başarıyla tamamlandı");
            }
            catch (Exception error)
            {
                return new ErrorResult("İşlem yapılamadı: " + error.Message);
            }
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
