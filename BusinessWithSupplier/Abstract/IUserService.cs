using Core.Entities.Concrete;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        void Update(User user);
        void AddUserOperationClaim(User user, int claimId);
        IDataResult<User> GetByEmailOrIdentiyName(string mailOrIdName);
        OperationClaim GetOperationClaim(string claimName);
        IList<User> GetUsers(string role = "");
        User GetUserById(int id);
        IResult ChangePassword(User user, string newPassword);
        IResult ChangeIdentityName(User user);
        IResult ChangeSupplierId(User user, int supplierId);
    }
}
