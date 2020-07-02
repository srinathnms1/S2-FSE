namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;

    public class AcceptBookingsQuery : IRequest<bool>
    {
        public AcceptBookingsQuery(AcceptBookingViewModel acceptBookingViewModel)
        {
            AcceptBookingViewModel = acceptBookingViewModel;
        }

        public AcceptBookingViewModel AcceptBookingViewModel { get; set; }
    }
}
