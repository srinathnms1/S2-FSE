namespace Booking.Domain.ViewModel
{
    using System;

    public class BookingViewModel
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime Date { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string CustomerName { get; set; }

        public int NumberOfPassanger { get; set; }

        public double CustomerMobile { get; set; }

        public string Status { get; set; }
    }
}
