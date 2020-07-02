namespace Booking.Domain.ViewModel
{
    using System;

    public class TripInfoViewModel
    {
        public Guid Id { get; set; }

        public Guid BookingId { get; set; }

        public Guid DriverId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? CompletedTime { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int NumberOfPassanger { get; set; }

        public decimal? Cost { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
