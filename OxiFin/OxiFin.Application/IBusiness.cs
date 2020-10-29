using OxiFin.Domain;
using OxiFin.Domain.Interfaces;
using System.Threading.Tasks;

namespace OxiFin.Application
{
    public interface IBusiness<T> : ICrud<T, long> where T : EntityBase<long>
    {
    }
}
