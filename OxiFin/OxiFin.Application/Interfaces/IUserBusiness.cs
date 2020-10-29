using OxiFin.Domain.Entities;
using System.Threading.Tasks;

namespace OxiFin.Application.Interfaces
{
    public interface IUserBusiness : IBusiness<UserApp>
    {
        Task DesativeAsync(long userId);
    }
}
