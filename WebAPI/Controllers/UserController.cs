using BusinessWithSupplier.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin,Supplier,Terminal")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getusers")]
        public IActionResult GetUser()
        {
            return Ok(_userService.GetUsers());
        }
        [HttpGet("getteminals")]
        public IActionResult GetUser(int supplierId)
        {
            IdName[] rest = (from selectUser in _userService.GetUsers("Terminal").Where(p => p.SupplierId == supplierId)
                             select new IdName
                             {
                                 Id = selectUser.Id,
                                 Name = selectUser.IdentityName
                             }).ToArray();
            return Ok(rest);
        }

        [HttpGet("getuserbyid")]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpGet("getuserbyidentityname")]
        public IActionResult GetUserByIdentityName(string identityName)
        {
            var result = _userService.GetByEmailOrIdentiyName(identityName);
            return Ok(result);
        }

        [HttpPost("adduseroperationclaim")]
        public IActionResult AddOperationClaim(string userName, string claimName)
        {
            var claim = _userService.GetOperationClaim(claimName);
            if (claim != null)
            {
                var user = _userService.GetByEmailOrIdentiyName(userName);
                if (user.Success)
                {
                    if (claimName == "Supplier")
                    {
                        user.Data.SupplierId = user.Data.Id;
                        _userService.Update(user.Data);
                    }
                    _userService.AddUserOperationClaim(user.Data, claim.Id);
                    return Ok(claim);
                }

            }
            return BadRequest("yetki eklemede sorun oldu");
        }

        [HttpPost("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                _userService.Update(user);
                return Ok(user);
            }
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword(ChangePassSpec data)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(data.NewPassword, out passwordHash, out passwordSalt);
            data.User.PasswordHash = passwordHash;
            data.User.PasswordSalt = passwordSalt;
            try
            {
                _userService.Update(data.User);
                return Ok("Şifre başarıyla değiştirildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    internal class IdName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ChangePassSpec
    {
        public User User { get; set; }
        public string NewPassword { get; set; }
    }
}
