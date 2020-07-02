namespace Booking.Infrastructure
{
    using Booking.Domain;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class TripRepository : GenericRepository<TripInfo>, ITripRepository
    {
        public TripRepository(BookingContext authContext)
        : base(authContext)
        {
        }

        public TripInfo GetTripByBookingId(Guid bookingId)
        {
            return GetAll().Include(i => i.Booking).FirstOrDefault(u => u.BookingId == bookingId);
        }
    }
}
