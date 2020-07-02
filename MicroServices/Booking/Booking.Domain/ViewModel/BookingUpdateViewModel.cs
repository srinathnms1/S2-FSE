namespace Booking.Domain.ViewModel
{
    using System;

    public class UpdateBookingViewModel
    {
        public string Status { get; set; }

        public Guid BookingId { get; set; }

        public Guid TripId { get; set; }
    }
}
