namespace Booking.Domain
{
    using Microservice.Core;
    using System;

    public interface ITripRepository : IGenericRepository<TripInfo>
    {
        TripInfo GetTripByBookingId(Guid bookingId);
    }
}
