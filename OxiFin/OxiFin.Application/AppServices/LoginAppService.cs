using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
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

        public async Task Login(UserApp_vw user)
        {
            var entity = Resolve(user);
            await _business.Login(entity);
        }
        
        public async Task LogOut(UserApp_vw user)
        {
            var entity = Resolve(user);
            await _business.LogOut(entity);
        }
    }
}
