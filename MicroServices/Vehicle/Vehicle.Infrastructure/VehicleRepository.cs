namespace Vehicle.Infrastructure
{
    using Vehicle.Domain;
    using Vehicle.Infrastracture;

    public class VehicleRepository : GenericRepository<VehicleInfo>, IVehicleRepository
    {
        public VehicleRepository(VehicleContext vehicleContext)
        : base(vehicleContext)
        {
        }
    }
}
