using BusinessWithSupplier.Abstract;
using CleaningEntities;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("loginwithuser")]
        public ActionResult LoginWithUser(UserForLoginDto userForLoginDto)
        {
            var userToLogin = authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            UserWithToken userWithToken = new UserWithToken()
            {
                Email = userToLogin.Data.Email,
                FirstName = userToLogin.Data.FirstName,
                LastName = userToLogin.Data.LastName,
                Id = userToLogin.Data.Id,
                SupplierId = (userToLogin.Data.SupplierId==0)?userToLogin.Data.Id:userToLogin.Data.SupplierId,
            };
           
            var result = authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                userWithToken.Token=result.Data.Token;
                return Ok(userWithToken);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
