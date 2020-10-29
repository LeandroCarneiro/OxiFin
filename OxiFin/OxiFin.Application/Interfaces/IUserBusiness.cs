using OxiFin.Domain.Entities;
using System.Threading.Tasks;

namespace OxiFin.Application.Interfaces
{
    public interface IUserBusiness : IBusiness<UserApp>
    {
        Task DesativeAsync(long userId);
    }

    public interface ILoginBusiness : IUserBusiness
    {
        Task<UserApp> Login(UserApp user);
        Task LogOut(UserApp user);
    }
}
