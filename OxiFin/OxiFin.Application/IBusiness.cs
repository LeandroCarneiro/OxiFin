using OxiFin.Common.InternalObjects;
using OxiFin.Domain.Interfaces;

namespace OxiFin.Application
{
    public interface IBusiness<T> : ICrud<T, long> where T : IEntity<long>
    {
    }
}
