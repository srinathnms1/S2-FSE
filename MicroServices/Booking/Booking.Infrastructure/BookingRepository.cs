namespace Booking.Infrastructure
{
    using Booking.Domain;

    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingContext authContext)
        : base(authContext)
        {
        }
    }
}
