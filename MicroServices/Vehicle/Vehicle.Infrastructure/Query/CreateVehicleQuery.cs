namespace Vehicle.Infrastructure.Query
{
    using Vehicle.Domain.ViewModel;
    using MediatR;
    using System;

    public class CreateVehicleQuery : IRequest<Guid>
    {
        public CreateVehicleQuery(VehicleViewModel vehicleViewModel)
        {
            VehicleViewModel = vehicleViewModel;
        }

        public VehicleViewModel VehicleViewModel { get; }
    }

}
