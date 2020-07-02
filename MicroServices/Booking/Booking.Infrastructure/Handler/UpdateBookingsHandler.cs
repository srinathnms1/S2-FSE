namespace Booking.Infrastructure.Handler
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class UpdateBookingsHandler : IRequestHandler<UpdateBookingsQuery, bool>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public UpdateBookingsHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBookingsQuery request, CancellationToken cancellationToken)
        {
            var booking = await this.bookingRepository.GetById(request.UpdateBookingViewModel.BookingId);
            mapper.Map(request.UpdateBookingViewModel, booking);
            booking = booking.BuildBooking(booking);

            return await this.bookingRepository.Update(booking.Id, booking);
        }
    }
}