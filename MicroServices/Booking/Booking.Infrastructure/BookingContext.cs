namespace Booking.Infrastructure
{
    using Authentication.Infrastracture;
    using Booking.Domain;
    using Microsoft.EntityFrameworkCore;

    public class BookingContext : DbContext
    {
        public DbSet<Booking> Booking { get; set; }
        public DbSet<TripInfo> TripInfo { get; set; }

        public BookingContext(DbContextOptions options) : base(options)
        {
        }
    }
}
