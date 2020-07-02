namespace Booking.Domain.ViewModel
{
    using System;

    public class AcceptBookingViewModel
    {
        public Guid DriverId { get; set; }

        public Guid BookingId { get; set; }
    }
}
