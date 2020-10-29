using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObjects;
using System;
using System.Threading.Tasks;

namespace OxiFin.Application.AppServices
{
    public class UserAppService : BaseAppService<UserApp_vw, UserApp>
    {
        readonly IUserBusiness _business;

        public UserAppService(IUserBusiness business) : base(business) 
        {
            _business = business;
        }

        public async Task DesativateAsync(long userId)
        {
            await _business.DesativeAsync(userId);
        }
    }
}
