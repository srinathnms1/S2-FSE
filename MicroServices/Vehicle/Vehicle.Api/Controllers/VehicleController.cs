namespace Vehicle.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Vehicle.Domain.ViewModel;
    using Vehicle.Infrastructure.Query;

    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public VehicleController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        // POST api/vehicle
        [HttpPost, Route("")]
        public async Task<Guid> Post(VehicleViewModel vehicleViewMode)
        {
            var vehicleId = await mediator.Send(new CreateVehicleQuery(vehicleViewMode));

            return vehicleId;
        }
    }
}
