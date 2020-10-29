using Microsoft.EntityFrameworkCore;
using OxiFin.Common.Exceptions;
using OxiFin.Domain;
using OxiFin.Mapping;
using OxiFin.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxiFin.Application
{
    public class BaseAppService<T_vw, T>
        where T_vw : EntityBase_vw<long>
        where T : EntityBase<long>
    {
        protected readonly IBusiness<T> _baseBusiness;

        public BaseAppService(IBusiness<T> business)
        {
            _baseBusiness = business;
        }

        public virtual long Add(T_vw obj)
        {
            return _baseBusiness.Add(Resolve(obj));
        }

        public virtual void Update(T_vw obj)
        {
            _baseBusiness.Update(Resolve(obj));
        }

        public virtual async Task<T_vw> FindByIdAsync(long id)
        {
            return Resolve(await _baseBusiness.SetIncluding.SingleOrDefaultAsync(x => x.Id == id));
        }

        #region resolver
        protected T_vw Resolve(T entity)
        {
            if (entity == null)
                throw new InvalidObjectException();

            return MappingWraper.Map<T, T_vw>(entity);
        }
        protected T Resolve(T_vw viewModel)
        {
            if (viewModel == null)
                throw new InvalidObjectException();

            return MappingWraper.Map<T_vw, T>(viewModel);
        }

        protected TTo Resolve<TFrom, TTo>(TFrom entity) where TFrom : EntityBase_vw<long> where TTo : EntityBase<long>
        {
            if (entity == null)
                throw new InvalidObjectException();

            return MappingWraper.Map<TFrom, TTo>(entity);
        }

        protected IEnumerable<T_vw> Resolve(IEnumerable<T> entity)
        {
            if (entity == null)
                throw new InvalidObjectException();

            return MappingWraper.Map<IEnumerable<T>, IEnumerable<T_vw>>(entity);
        }
        protected IEnumerable<T> Resolve(IEnumerable<T_vw> viewModel)
        {
            if (viewModel == null)
                throw new InvalidObjectException();

            return MappingWraper.Map<IEnumerable<T_vw>, IEnumerable<T>>(viewModel);
        }
        #endregion
    }
}
