using Microsoft.AspNetCore.Identity;
using OxiFin.Common.InternalObjects;
using OxiFin.DI;
using OxiFin.Domain.Entities.Auth;
using OxiFin.ViewModels.AppObjects;
using System.Threading.Tasks;

namespace OxiFin.Application.AppServices
{
    public class LoginAppService
    {
        private readonly SignInManager<UserApp> _userManager;

        public LoginAppService() 
        {
            _userManager = AppContainer.Resolve<SignInManager<UserApp>>();
        }

        public async Task<AppResult> Login(Login_vw user)
        {
            var entity = Mapping.MappingWraper.Map<Login_vw, UserApp>(user);
            await _userManager.SignInAsync(entity,true);

            return new AppResult();
        }
        
        public async Task LogOut()
        {
            await _userManager.SignOutAsync();
        }
    }
}
