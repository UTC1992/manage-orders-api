using System;
using orders.Domain.Interfaces;

namespace orders.Domain.Entities
{
  public abstract class BaseEntity : IBaseEntity
  {
    public Guid Id { get; init; }

    protected BaseEntity()
    {
      this.Id = Guid.NewGuid();
    }
  }
}

