using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
using System.Threading.Tasks;

namespace OxiFin.Business.Domain
{
    public class UserBusiness : AppBusiness<UserApp>, IUserBusiness
    {
        public async Task DesativeAsync(long userId)
        {
            using(var trans = _uow.BeginTransaction())
            {
                var user = await FindById(userId);
                user.Active = false;

                Update(user);
                await trans.CommitAsync();
            }
        }
    }
}
