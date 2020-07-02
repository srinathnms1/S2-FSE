namespace Booking.Infrastructure.Handler
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class UpdateBookingTripInfoHandler : IRequestHandler<UpdateBookingTripInfoQuery, bool>
    {
        private readonly ITripRepository tripRepository;
        private readonly IMapper mapper;

        public UpdateBookingTripInfoHandler(ITripRepository tripRepository, IMapper mapper)
        {
            this.tripRepository = tripRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBookingTripInfoQuery request, CancellationToken cancellationToken)
        {
            var tripInfo = this.tripRepository.GetTripByBookingId(request.UpdateBookingViewModel.BookingId);
            if (tripInfo == null)
            {
                return true;
            }

            mapper.Map(request.UpdateBookingViewModel, tripInfo);

            var booking = tripInfo.BuildTrip(tripInfo);

            return await this.tripRepository.Update(booking.Id, tripInfo);
        }
    }
}