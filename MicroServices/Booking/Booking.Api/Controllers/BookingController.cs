namespace Booking.Api.Controllers
{
    using Booking.Infrastructure.Query;
    using Booking.Domain.ViewModel;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/booking")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IMediator mediator;
        public BookingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/booking
        [HttpGet, Route("pending")]
        public async Task<IEnumerable<BookingViewModel>> PendingBookings()
        {
            var bookings = await this.mediator.Send(new GetBookingsQuery(null));
            return bookings;
        }

        // GET api/booking
        [HttpGet, Route("{userId}")]
        public async Task<IEnumerable<BookingViewModel>> PendingCustomerBookings(Guid userId)
        {
            var bookings = await this.mediator.Send(new GetBookingsQuery(userId));
            return bookings;
        }

        [HttpPost, Route("create")]
        public async Task<bool> CreateBooking([FromBody]BookingViewModel bookingViewModel)
        {
            var isSuccess = await mediator.Send(new CreateBookingsQuery(bookingViewModel));

            return isSuccess;
        }

        [HttpPut, Route("accept")]
        public async Task<bool> AcceptBooking([FromBody]AcceptBookingViewModel acceptBookingViewModel)
        {
            await mediator.Send(new AcceptBookingsQuery(acceptBookingViewModel));
            var isSuccess = await mediator.Send(new ScheduleTripQuery(acceptBookingViewModel));

            return isSuccess;
        }

        [HttpPut, Route("update")]
        public async Task<bool> UpdateBooking([FromBody]UpdateBookingViewModel updateBookingViewModel)
        {
            await mediator.Send(new UpdateBookingsQuery(updateBookingViewModel));

            return await mediator.Send(new UpdateBookingTripInfoQuery(updateBookingViewModel));
        }
    }
}
