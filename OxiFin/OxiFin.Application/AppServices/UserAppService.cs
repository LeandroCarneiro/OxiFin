using Extensions;
using JwtAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OxiFin.Application.Interfaces;
using OxiFin.Common.InternalObjects;
using OxiFin.DI;
using OxiFin.Domain.Entities.Auth;
using OxiFin.ViewModels.AppObject;
using OxiFin.ViewModels.AppObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OxiFin.Application.AppServices
{
    public class UserAppService : BaseAppService<UserApp_vw, UserApp>
    {
        readonly IUserBusiness _business;
        private readonly UserManager<UserApp> _userManager;
        private readonly IConfiguration _config;

        public UserAppService(IUserBusiness business) : base(business)
        {
            _userManager = AppContainer.Resolve<UserManager<UserApp>>();
            _business = business;
        }

        public async Task DesativateAsync(long userId)
        {
            await _business.DesativeAsync(userId);
        }

        public async Task<AppResult> AddUserToRole(string userName, string roleName)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == userName);
            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
                return new AppResult();
            else
                return new AppResult(result.Errors);
        }

        public async Task<AppResult> SignIn(Login_vw request)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);
            if (user is null)            
                return new AppResult("User not found");
            
            var userSigninResult = await _userManager.CheckPasswordAsync(user, request.Password);

            if (userSigninResult)
            {
                var vw = Resolve<UserApp, UserLogged>(user);
                var roles = await _userManager.GetRolesAsync(user);
                var resut = JwtAuthenticator.GenerateToken(vw, roles);

                return new AppResult(resut);
            }

            return new AppResult("Wrong Password");
        }

        public async Task<AppResult> SignUp(UserApp_vw request)
        {
            var user = Resolve(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                return new AppResult(result);

            return new AppResult(result.ToString());
        }
    }
}
