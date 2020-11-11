using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OxiFin.Application.Interfaces;
using OxiFin.Common.InternalObjects;
using OxiFin.DI;
using OxiFin.Domain.Entities.Auth;
using OxiFin.ViewModels.AppObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OxiFin.Application.AppServices
{
    public class UserAppService : BaseAppService<UserApp_vw, UserApp>
    {
        readonly IUserBusiness _business;
        private readonly UserManager<UserApp> _userManager;
        
        public UserAppService(IUserBusiness business) : base(business)
        {
            _userManager = AppContainer.Resolve<UserManager<UserApp>>();
            _business = business;
        }

        public async Task DesativateAsync(long userId)
        {
            await _business.DesativeAsync(userId);
        }

        public async Task<AppResult> SignIn(Login_vw request)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == request.Username);
            if (user is null)            
                return new AppResult("User not found");
            
            var userSigninResult = await _userManager.CheckPasswordAsync(user, request.EncriptPassword);

            if (userSigninResult)            
                return new AppResult(Resolve(user));

            return new AppResult("Wrong Password");
        }

        public async Task<AppResult> SignUp(UserApp_vw request)
        {
            var user = Resolve(request);
            var result = await _userManager.CreateAsync(user, request.EncriptPassword);

            if (result.Succeeded)
                return new AppResult(result);

            return new AppResult(result.ToString());
        }
    }
}
