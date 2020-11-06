using OxiFin.DI;
using OxiFin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OxiFin.Domain;

namespace OxiFin.Business
{
    public abstract class AppBusiness<TEntity> : ICrud<TEntity, long> where TEntity : EntityBase<long>
    {
        protected readonly IDbContext _uow;
        protected DbSet<TEntity> Set => _uow.GetEntity<TEntity>();

        public AppBusiness()
        {
            _uow = AppContainer.Resolve<IDbContext>();            
        }

        public long Add(TEntity obj)
        {
            using (var trans = _uow.BeginTransaction())
            {
                _uow.GetEntity<TEntity>().Add(obj);
                trans.Commit();
                _uow.Commit();

                return obj.Id;
            }
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> expression, bool asNoTracking = false)
        {
            return asNoTracking ? 
                await Set.AsNoTracking().SingleOrDefaultAsync(expression)
                :
                await Set.SingleOrDefaultAsync(expression);
        }

        public async Task<TEntity> FindById(long id, bool asNoTracking = false)
        {
            return asNoTracking ?
                await Set.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) 
                :
                await Set.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> expression)
        {
            return await Set.Where(expression).ToListAsync();
        }

        public void Update(TEntity obj)
        {
            if (obj == null)
                return;

            using (var trans = _uow.BeginTransaction())
            {
                var exist = _uow.GetEntity<TEntity>().SingleOrDefault(x => x.Id == obj.Id);
                if (exist != null)
                {
                    _uow.EntryEntity(obj).CurrentValues.SetValues(obj);
                    _uow.Commit();
                }
            }
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}