namespace Booking.Infrastructure.Handler
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Domain.ViewModel;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class GetTripsHandler : IRequestHandler<GetTripsQuery, List<TripInfoViewModel>>
    {
        private readonly ITripRepository tripRepository;
        private readonly IMapper mapper;

        public GetTripsHandler(ITripRepository tripRepository, IMapper mapper)
        {
            this.tripRepository = tripRepository;
            this.mapper = mapper;
        }

        public Task<List<TripInfoViewModel>> Handle(GetTripsQuery request, CancellationToken cancellationToken)
        {
            var trips = this.tripRepository.GetAll().Where(u => u.DriverId == request.Id || u.Booking.CustomerId == request.Id).ToList();
            var tripViewModel = mapper.Map<List<TripInfoViewModel>>(trips);
            return Task.Run(() => tripViewModel);
        }
    }
}