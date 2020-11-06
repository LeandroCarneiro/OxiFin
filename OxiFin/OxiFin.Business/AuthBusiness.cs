using OxiFin.DI;
using OxiFin.Domain.Interfaces;
using OxiFin.Common.InternalObjects;

namespace OxiFin.Business
{
    public abstract class AuthBusiness<TEntity> where TEntity : IEntity<long>
    {
        protected readonly IDbContext _uow;
        
        public AuthBusiness()
        {
            _uow = AppContainer.Resolve<IDbContext>();            
        }
    }
}