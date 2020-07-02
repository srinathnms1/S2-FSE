namespace Booking.Infrastructure.Handler
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class AcceptBookingsHandler : IRequestHandler<AcceptBookingsQuery, bool>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public AcceptBookingsHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(AcceptBookingsQuery request, CancellationToken cancellationToken)
        {
            var booking = await this.bookingRepository.GetById(request.AcceptBookingViewModel.BookingId);
            mapper.Map(request.AcceptBookingViewModel, booking);
            booking = booking.BuildBooking(booking, Domain.Types.BookingStatus.Confirmed);
            await this.bookingRepository.Update(booking.Id, booking);

            return true;
        }
    }
}