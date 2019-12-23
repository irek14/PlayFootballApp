using Microsoft.AspNetCore.Identity;
using PlayFootballApp.BuisnessEntities.Entities;
using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Models.Account;
using PlayFootballApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayFootballApp.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        PlayFootballContext _context;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PlayFootballContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(RegisterViewModel user)
        {
            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = user.Email.ToLower(),
                UserName = user.Email.ToLower(),
                EmailConfirmed = true,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, isPersistent: false);

                await _context.SaveChangesAsync();

                return null;
            };
            return result;
        }

        public async Task<bool> LogIn(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, false, false);
                if (result.Succeeded)
                    return true;

                return false;
            }

            return false;
        }
    }


}
