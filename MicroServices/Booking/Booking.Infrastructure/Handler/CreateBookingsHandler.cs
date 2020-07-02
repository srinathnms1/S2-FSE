namespace Booking.Infrastructure.Handler
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Booking.Domain;
    using Booking.Infrastructure.Query;
    using MediatR;

    public class CreateBookingsHandler : IRequestHandler<CreateBookingsQuery, bool>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public CreateBookingsHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        public Task<bool> Handle(CreateBookingsQuery request, CancellationToken cancellationToken)
        {
            var booking = mapper.Map<Booking>(request.BookingViewModel);
            booking.BuildBooking();
            this.bookingRepository.Create(booking);
            return Task.Run(() => true);
        }
    }
}