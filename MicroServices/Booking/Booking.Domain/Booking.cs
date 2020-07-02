namespace Booking.Domain
{
    using Types;
    using Microservice.Core;
    using System;

    public class Booking: IEntity, IAuditEntity
    {
        public Booking BuildBooking()
        {
            Id = Guid.NewGuid();
            CreatedBy = "System";
            UpdatedBy = "System";
            UpdatedOn = DateTime.Now;
            CreatedOn = DateTime.Now;
            Status = BookingStatus.Pending.ToString();
            return this;
        }

        public Booking BuildBooking(Booking booking)
        {
            booking.UpdatedBy = "System";
            booking.UpdatedOn = DateTime.Now;

            return this;
        }

        public Booking BuildBooking(Booking booking, BookingStatus bookingStatus)
        {
            booking.UpdatedBy = "System";
            booking.UpdatedOn = DateTime.Now;
            booking.Status = bookingStatus.ToString();

            return this;
        }


        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime Date { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string CustomerName { get; set; }

        public double CustomerMobile { get; set; }

        public int NumberOfPassanger { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public string Status { get; set; }
    }
}
