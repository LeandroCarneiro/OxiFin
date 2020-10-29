using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
using System.Threading.Tasks;

namespace OxiFin.Business.Domain
{
    public class LoginBusiness : UserBusiness, ILoginBusiness
    {
        public async Task<UserApp> Login(UserApp user)
        {
            var result = await Find(x => x.Active && x.Email == user.Email);
            return result;
        }

        public Task LogOut(UserApp user)
        {
            throw new System.NotImplementedException();
        }
    }
}
