﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OxiFin.Domain.Interfaces
{
    public interface ICrud<T, TIdType>
    {
        TIdType Add(T obj);
        void Update(T obj);
        Task<T> FindById(TIdType id, bool asNoTracking = false);
        Task<T> Find(Expression<Func<T, bool>> expression, bool asNoTracking = false);
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> expression);

        IQueryable<T> SetIncluding { get; }
        IQueryable<T> SetIncludingTracking { get; }
    }
}
