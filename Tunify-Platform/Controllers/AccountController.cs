using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccounts _IAccounts;
        public AccountController(IAccounts context)
        {
            _IAccounts = context;
        }
        // Register
        [HttpPost("Register")]
        public async Task<ActionResult<RegisterDto>> Register(RegisterDto registerdUserDto )
        {
          var account =  await _IAccounts.Register(registerdUserDto, this.ModelState);
            if (ModelState.IsValid)
            {
                return account;
            }
            if (account == null)
            {
                return Unauthorized();
            }
            return BadRequest();
        }
        // Login
        [HttpPost("Login")]
        public async Task<ActionResult<RegisterDto>> Login(LoginDto loginDto)
        {
            var account=  await _IAccounts.UserAuthentication(loginDto.Username, loginDto.Password);
            if (account == null)
            {
                return Unauthorized();
            }
            return account;
        }
        // LogOut
        [HttpPost("LogOut")]
        public async Task<ActionResult<RegisterDto>> LogOut(LogOutDto user)
        {
            var account = await _IAccounts.LogOut(user);
            return account;
        }
    }
}
