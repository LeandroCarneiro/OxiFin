using System;
using System.ComponentModel.DataAnnotations;

namespace OxiFin.Domain
{
    public interface IEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }     
    }

    public interface IEntity<T> : IEntity
    {
        [Key]
        T Id { get; set; }
    }

    public class EntityBase<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
