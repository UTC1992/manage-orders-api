using System;
namespace orders_api.Commands
{
	public record CreateOrderCommand(Guid orderId, string Address);  
}

