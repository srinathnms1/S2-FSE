namespace Authentication.Infrastracture
{
    using Booking.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookingConfiguration : IEntityTypeConfiguration<TripInfo>
    {
        public void Configure(EntityTypeBuilder<TripInfo> builder)
        {
            builder.HasKey(s => new { s.BookingId });
        }
    }
}