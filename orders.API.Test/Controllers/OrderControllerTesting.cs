using System.Net;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using orders.API.Commands;
using orders.API.Controllers;
using orders.API.DTOs;
using orders.API.Queries;
using orders.Domain.Entities;
using orders.Infrastructure;
using orders_api_test.ServiceTestsFixture;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace orders.API.Test;

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
        // Arrange
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
        Assert.IsType<OrderDto>(result.Value);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedResponse, result.Value);
    }

    [Fact]
    public async Task TestShouldUpdateOrder_ReturnOrderUpdated()
    {
        // Arrange
        var OrderId = Guid.Parse("92b3bff2-b461-4789-b049-fcab835aea6b");
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
        Assert.IsType<OrderDto>(result.Value);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(expectedResponse, result.Value);
    }

    [Fact]
    public async Task TestSholdGetOrdersByProductId_ReturnOrdersList()
    {
        // Arrange
        var ProductId = Guid.Parse("92b3bff2-b461-4789-b049-fcab835aea6b");

        var expectedResponse = new List<OrderDto>();
        expectedResponse.Add(new OrderDto
        {
            Id = Guid.NewGuid(),
            Address = "Street 12-39",
        });
        var query = new GetOrdersByProductIdQuery(ProductId, 1, 0);

        this._mediator.Setup(x => x.Send(query, CancellationToken.None))
            .ReturnsAsync(expectedResponse);
        // Act
        var result = await this._orderController.GetOrdersByProductId(ProductId, 1, 0) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        var orders = Assert.IsType<List<OrderDto>>(result.Value);
        Assert.True(orders.Count > 0);

    }

    [Fact]
    public async Task TestSholdGetProductsByOrderId_ReturnProductList()
    {
        // Arrange
        var OrderId = Guid.Parse("92b3bff2-b461-4789-b049-fcab835aea6b");
        var expectedResponse = new List<ProductDto>();
        expectedResponse.Add(new ProductDto
        {
            Id = Guid.NewGuid(),
            Name = "Milk",
            Price = 1.2m
        });
        var query = new GetProductsByOrderIdQuery(OrderId);

        this._mediator.Setup(x => x.Send(query, CancellationToken.None))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await this._orderController.GetProductsByOrderId(OrderId) as OkObjectResult;


        // Assert
        Assert.NotNull(result);
        var products = Assert.IsType<List<ProductDto>>(result.Value);
        Assert.True(products.Count > 0);
    }

    [Fact]
    public async Task TestSholdDeleteOrder_ReturnOk()
    {
        // Arrange
        var OrderId = Guid.Parse("92b3bff2-b461-4789-b049-fcab835aea6b");

        // Act
        var result = await this._orderController.DeleteOrder(OrderId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
