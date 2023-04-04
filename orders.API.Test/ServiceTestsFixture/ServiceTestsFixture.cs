using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using orders.API.Controllers;

namespace orders_api_test.ServiceTestsFixture
{
    public class ServiceTestsFixture
    {
        public Mock<IMediator> MediatorMock { get; }
        public Mock<ILogger<OrderController>> LoggerMock { get; }

        public ServiceTestsFixture()
        {
            MediatorMock = new Mock<IMediator>();
            LoggerMock = new Mock<ILogger<OrderController>>();
        }
    }
}

