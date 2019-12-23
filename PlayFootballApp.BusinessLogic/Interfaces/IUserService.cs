using Microsoft.AspNetCore.Identity;
using PlayFootballApp.BusinessLogic.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayFootballApp.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> AddUser(RegisterViewModel user);

        Task<bool> LogIn(LoginModel loginModel);

        Task LogOut();
    }
}
