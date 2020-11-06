using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities.Auth;
using OxiFin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OxiFin.Business.Auth
{
    public class UserBusiness : IUserBusiness
    {
        protected readonly IDbContext _uow;
        
        public long Add(UserApp obj)
        {
            throw new NotImplementedException();
        }

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

        public Task<UserApp> Find(Expression<Func<UserApp, bool>> expression, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<UserApp> FindById(long id, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserApp>> List(Expression<Func<UserApp, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(UserApp obj)
        {
            throw new NotImplementedException();
        }
    }
}
