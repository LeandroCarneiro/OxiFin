﻿using OxiFin.Domain;
using OxiFin.Domain.Interfaces;

namespace OxiFin.Application
{
    public interface IBusiness<T> : ICrud<T, long> where T : EntityBase<long>
    {
    }
}
