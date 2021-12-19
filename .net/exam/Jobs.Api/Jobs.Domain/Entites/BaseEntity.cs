namespace Jobs.Domain.Entites
{
using System;
 public abstract   class BaseEntity
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();

        public bool IsDeleted { get; set; } = false;

    }
}
