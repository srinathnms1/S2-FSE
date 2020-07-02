namespace Booking.Infrastructure.Handler
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class ScheduleTripHandler : IRequestHandler<ScheduleTripQuery, bool>
    {
        private readonly IMapper mapper;
        private readonly IBookingRepository bookingRepository;
        private readonly ITripRepository tripRepository;

        public ScheduleTripHandler(IMapper mapper, IBookingRepository bookingRepository, ITripRepository tripRepository)
        {
            this.mapper = mapper;
            this.bookingRepository = bookingRepository;
            this.tripRepository = tripRepository;
        }

        public Task<bool> Handle(ScheduleTripQuery request, CancellationToken cancellationToken)
        {
            var bookingInfo = this.bookingRepository.GetAll().FirstOrDefault(u => u.Id == request.AcceptBookingViewModel.BookingId);
            var tripInfo = this.mapper.Map<TripInfo>(bookingInfo);
            tripInfo.BuildTrip(tripInfo, request.AcceptBookingViewModel.DriverId);
            this.tripRepository.Create(tripInfo);
            return Task.Run(() => true);
        }
    }
}