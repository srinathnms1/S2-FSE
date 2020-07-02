namespace Booking.Api.Tests
{
    using Booking.Api.Controllers;
    using MediatR;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class BookingControllerTests
    {
        [TestMethod]
        public async void Get()
        {
            // Arrange    
            Moq.Mock<IMediator> mediator = new Moq.Mock<IMediator>();

            var controller = new BookingController(mediator.Object);

            // Act
            await controller.PendingCustomerBookings(Guid.NewGuid());
        }
    }
}
