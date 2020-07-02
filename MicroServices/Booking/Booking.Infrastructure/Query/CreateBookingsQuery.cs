namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;
    using System;

    public class CreateBookingsQuery : IRequest<bool>
    {
        public CreateBookingsQuery(BookingViewModel bookingViewModel)
        {
            BookingViewModel = bookingViewModel;
        }

        public BookingViewModel BookingViewModel { get; set; }
    }
}
