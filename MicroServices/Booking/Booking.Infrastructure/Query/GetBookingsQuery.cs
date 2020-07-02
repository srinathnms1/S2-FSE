namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetBookingsQuery : IRequest<List<BookingViewModel>>
    {
        public GetBookingsQuery(Guid? userId)
        {
            UserId = userId;
        }

        public Guid? UserId { get; set; }
    }
}
