using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace orders.Infrastructure.Context.Entities
{
	public class BaseEntity
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }
	}
}

