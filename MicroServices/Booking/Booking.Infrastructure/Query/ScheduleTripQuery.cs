namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;

    public class ScheduleTripQuery : IRequest<bool>
    {
        public ScheduleTripQuery(AcceptBookingViewModel acceptBookingViewModel)
        {
            AcceptBookingViewModel = acceptBookingViewModel;
        }

        public AcceptBookingViewModel AcceptBookingViewModel { get; set; }
    }
}
