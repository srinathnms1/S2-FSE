namespace Vehicle.Infrastracture
{
    using Vehicle.Domain;
    using Microsoft.EntityFrameworkCore;

    public class VehicleContext : DbContext
    {
        public DbSet<VehicleInfo> VehicleInfo { get; set; }

        public VehicleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleInfoConfiguration());
        }
    }
}
