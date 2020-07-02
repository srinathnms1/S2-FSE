namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;

    public class UpdateBookingTripInfoQuery : IRequest<bool>
    {
        public UpdateBookingTripInfoQuery(UpdateBookingViewModel updateBookingViewModel)
        {
            UpdateBookingViewModel = updateBookingViewModel;
        }

        public UpdateBookingViewModel UpdateBookingViewModel { get; set; }
    }
}
