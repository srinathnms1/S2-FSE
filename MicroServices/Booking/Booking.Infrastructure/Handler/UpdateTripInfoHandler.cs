namespace Booking.Infrastructure.Handler
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class UpdateTripInfoHandler : IRequestHandler<UpdateTripInfoQuery, bool>
    {
        private readonly ITripRepository tripRepository;
        private readonly IMapper mapper;

        public UpdateTripInfoHandler(ITripRepository tripRepository, IMapper mapper)
        {
            this.tripRepository = tripRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateTripInfoQuery request, CancellationToken cancellationToken)
        {
            var tripInfo = await this.tripRepository.GetById(request.TripInfoUpdateViewModel.TripId);
            mapper.Map(request.TripInfoUpdateViewModel, tripInfo);

            var booking = tripInfo.BuildTrip(tripInfo);

            return await this.tripRepository.Update(booking.Id, tripInfo);
        }
    }
}