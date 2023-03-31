using System;
namespace orders.Domain.Interfaces
{
	public interface IBaseEntity
	{
		public Guid Id { get; init; }
	}
}

