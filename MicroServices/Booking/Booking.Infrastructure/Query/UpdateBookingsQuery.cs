namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;

    public class UpdateBookingsQuery : IRequest<bool>
    {
        public UpdateBookingsQuery(UpdateBookingViewModel updateBookingViewModel)
        {
            UpdateBookingViewModel = updateBookingViewModel;
        }

        public UpdateBookingViewModel UpdateBookingViewModel { get; set; }
    }
}
