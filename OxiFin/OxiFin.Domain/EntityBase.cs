using OxiFin.Common.InternalObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace OxiFin.Domain
{
    public class EntityBase<T> : IEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
