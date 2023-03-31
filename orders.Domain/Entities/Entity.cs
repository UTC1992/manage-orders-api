using System;
using orders.Domain.Interfaces;

namespace orders.Domain.Entities
{
  public abstract class Entity : IEntity
  {
    public Guid Id { get; init; }

    protected Entity()
    {
      this.Id = Guid.NewGuid();
    }
  }
}

