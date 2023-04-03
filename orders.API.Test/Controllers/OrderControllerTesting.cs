using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using orders.API.Commands;
using orders.API.Controllers;
using orders.API.DTOs;

namespace orders.API.Test;

public class ExampleServiceTestsFixture
{
    public Mock<IMediator> MediatorMock { get; }

    public ExampleServiceTestsFixture()
    {
        MediatorMock = new Mock<IMediator>();
    }
}

public class OrderControllerTesting : IClassFixture<ExampleServiceTestsFixture>
{
    private readonly OrderController _orderController;
    private readonly Mock<IMediator> _mediator;

    public OrderControllerTesting(ExampleServiceTestsFixture fixture)
    {
        _mediator = fixture.MediatorMock;
        this._orderController = new OrderController(this._mediator.Object);
    }

    [Fact]
    public async Task TestShouldSaveOrder_ReturnOrderSaved()
    {
        // arrange
        var OrderId = Guid.NewGuid();
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

    }
}
