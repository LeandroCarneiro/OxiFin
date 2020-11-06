using OxiFin.Common.InternalObjects;
using System;

namespace OxiFin.ViewModels
{
    public class EntityBase_vw<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
