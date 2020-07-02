namespace Vehicle.Infrastracture
{
    using Vehicle.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VehicleInfoConfiguration : IEntityTypeConfiguration<VehicleInfo>
    {
        public void Configure(EntityTypeBuilder<VehicleInfo> builder)
        {
            builder.HasKey(s => new { s.Id });
        }
    }
}