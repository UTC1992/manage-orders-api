using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using orders.API.Commands;
using orders.API.Controllers;
using orders.API.DTOs;

namespace orders.API.Test;

public class ServiceTestsFixture
{
    public Mock<IMediator> MediatorMock { get; }
    public Mock<ILogger<OrderController>> LoggerMock { get;  }

    public ServiceTestsFixture()
    {
        MediatorMock = new Mock<IMediator>();
        LoggerMock = new Mock<ILogger<OrderController>>();
    }
}

public class OrderControllerTesting : IClassFixture<ServiceTestsFixture>
{
    private readonly OrderController _orderController;
    private readonly Mock<IMediator> _mediator;
    private readonly Mock<ILogger<OrderController>> _logger;

    public OrderControllerTesting(ServiceTestsFixture fixture)
    {
        this._mediator = fixture.MediatorMock;
        this._logger = fixture.LoggerMock;
        this._orderController = new OrderController(this._mediator.Object, this._logger.Object);
    }

    [Fact]
    public async Task TestShouldSaveOrder_ReturnOrderSaved()
    {
        // arrange
        var OrderId = Guid.Parse("92b3bff2-b461-4789-b049-fcab835aea6b");
        var Address = "Street 11-23";

        var productsId = new List<Guid>();
        productsId.Add(Guid.NewGuid());
        var expectedResponse = new OrderDto{
            Id = OrderId,
            Address = Address,
        };
        var command = new CreateOrderCommand(Address, productsId);

        this._mediator.Setup(x => x.Send(command, CancellationToken.None))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await this._orderController.AddOrder(command) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedResponse, result.Value);
    }

    [Fact]
    public async Task TestShouldUpdateOrder_ReturnOrderUpdated()
    {
        // arrange
        var OrderId = Guid.Parse("92b3bff2-b461-4789-b049-fcab835aea6b"); ;
        var Address = "Street 11-23 updated";

        var productsId = new List<Guid>();
        productsId.Add(Guid.NewGuid());
        var expectedResponse = new OrderDto
        {
            Id = OrderId,
            Address = Address,
        };
        var command = new UpdateOrderCommand(OrderId, Address, productsId);

        this._mediator.Setup(x => x.Send(command, CancellationToken.None))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await this._orderController.UpdateOrder(OrderId, command) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedResponse, result.Value);
    }
}
