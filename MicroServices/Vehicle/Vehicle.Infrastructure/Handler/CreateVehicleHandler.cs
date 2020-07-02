namespace Vehicle.Infrastructure.Handler
{
    using System.Threading;
    using System.Threading.Tasks;
    using Vehicle.Domain;
    using Vehicle.Infrastructure.Query;
    using AutoMapper;
    using MediatR;
    using System;

    public class CreateVehicleHandler : IRequestHandler<CreateVehicleQuery, Guid>
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository vehicleRepository;

        public CreateVehicleHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            this.mapper = mapper;
            this.vehicleRepository = vehicleRepository;
        }

        public Task<Guid> Handle(CreateVehicleQuery request, CancellationToken cancellationToken)
        {
            var vehicleInfo = mapper.Map<VehicleInfo>(request.VehicleViewModel);
            vehicleInfo.BuildVehicleInfo();

            return this.vehicleRepository.Create(vehicleInfo);
        }
    }
}