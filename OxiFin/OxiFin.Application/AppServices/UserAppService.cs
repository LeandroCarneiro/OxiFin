using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.Application.AppServices
{
    public class UserAppService : BaseAppService<UserApp_vw, UserApp>
    {
        public UserAppService(IUserBusiness business) : base(business) { }
    }
}
