using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountService : IAccounts
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public IdentityAccountService(UserManager<IdentityUser> Manager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = Manager;
            _signInManager = signInManager;
        }
        // Register User
        public async Task<RegisterDto> Register(RegisterDto registerdUserDto, ModelStateDictionary modelState)
        {
            var user = new IdentityUser()
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,
            };
            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);
            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerdUserDto) :
                                error.Code.Contains("Email") ? nameof(registerdUserDto) :
                                error.Code.Contains("Username") ? nameof(registerdUserDto) : "";
                modelState.AddModelError(errorCode, error.Description);
            }
            return null;
        }
        // LogIn
        public async Task<RegisterDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            bool passValidation = await _userManager.CheckPasswordAsync(user, password);
            if (passValidation)
            {
                return new RegisterDto()
                {                
                    UserName = user.UserName
                };
            }
            return null;
        }
        // LogOut
        public async Task<RegisterDto> LogOut(LogOutDto user)
        {
            var user1 = await _userManager.FindByNameAsync(user.user.Username);
            if (user1 == null) return null;
            await _signInManager.SignOutAsync();
            var result = new RegisterDto()
            {
                UserName = user1.UserName
            };
            return result;
        }
    }
}
