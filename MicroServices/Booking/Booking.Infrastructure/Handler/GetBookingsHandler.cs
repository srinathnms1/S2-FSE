namespace Booking.Infrastructure.Handler
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Domain.Types;
    using Booking.Domain.ViewModel;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class GetBookingsHandler : IRequestHandler<GetBookingsQuery, List<BookingViewModel>>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public GetBookingsHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        public Task<List<BookingViewModel>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var pendingBookings = this.bookingRepository
                .GetAll()
                .Where(u => u.Status == BookingStatus.Pending.ToString() && 
                (request.UserId == null ? true: request.UserId == u.CustomerId)).ToList();

            var bookingViewModel = mapper.Map<List<BookingViewModel>>(pendingBookings);
            return Task.Run(() => bookingViewModel);
        }
    }
}