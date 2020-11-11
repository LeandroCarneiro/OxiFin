using Microsoft.EntityFrameworkCore;
using OxiFin.Common.Exceptions;
using OxiFin.Common.InternalObjects;
using OxiFin.Domain;
using OxiFin.Mapping;
using OxiFin.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxiFin.Application
{
    public class BaseAppService<T_vw, T>
        where T_vw : IEntity<long>
        where T : IEntity<long>
    {
        protected readonly IBusiness<T> _baseBusiness;

        public BaseAppService(IBusiness<T> business)
        {
            _baseBusiness = business;
        }

        public virtual AppResult Add(T_vw obj)
        {
            return new AppResult(_baseBusiness.Add(Resolve(obj)));
        }

        public virtual void Update(T_vw obj)
        {
            _baseBusiness.Update(Resolve(obj));
        }

        public virtual async Task<AppResult<T_vw>> FindByIdAsync(long id)
        {
            var result = await _baseBusiness.FindById(id, true);
            
            if (result == null)
                return new AppResult<T_vw>("Not found");

            return new AppResult<T_vw>(Resolve(result));
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
