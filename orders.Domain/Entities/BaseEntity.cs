using System;
using orders.Domain.Interfaces;

namespace orders.Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; private set; }

        protected BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }

        public void SetId(Guid Id)
        {
            this.Id = Id;
        }
    }
}

