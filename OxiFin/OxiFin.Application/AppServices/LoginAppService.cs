using OxiFin.Application.Interfaces;
using OxiFin.Common.InternalObjects;
using OxiFin.Domain.Entities;
using OxiFin.Domain.Entities.Auth;
using OxiFin.ViewModels.AppObjects;
using System.Threading.Tasks;

namespace OxiFin.Application.AppServices
{
    public class LoginAppService : BaseAppService<UserApp_vw, UserApp>
    {
        readonly ILoginBusiness _business;

        public LoginAppService(ILoginBusiness business) : base(business) 
        {
            _business = business;
        }

        public async Task<AppResult> Login(UserApp_vw user)
        {
            var entity = Resolve(user);
            var result = await _business.Login(entity);

            return new AppResult(result);
        }
        
        public async Task LogOut(UserApp_vw user)
        {
            var entity = Resolve(user);
            await _business.LogOut(entity);
        }
    }
}
