namespace Booking.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using System.Threading.Tasks;
    using Booking.Infrastructure.Query;
    using System;
    using Booking.Domain.ViewModel;
    using System.Collections.Generic;

    [ApiController]
    [Authorize]
    public class TripController : ControllerBase
    {
        private readonly IMediator mediator;
        public TripController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET api/trip
        [HttpGet, Route("api/trip/{userId}")]
        public async Task<IEnumerable<TripInfoViewModel>> Get(Guid userId)
        {
            var trips = await this.mediator.Send(new GetTripsQuery(userId));
            return trips;
        }

        // POST api/trip/update/{tripId}
        [HttpPost, Route("api/trip/start")]
        public async Task<bool> Start([FromBody]TripInfoUpdateViewModel tripInfoUpdateViewModel)
        {
            var isSuccess = await this.mediator.Send(new UpdateTripInfoQuery(tripInfoUpdateViewModel));
            return isSuccess;
        }
    }
}
