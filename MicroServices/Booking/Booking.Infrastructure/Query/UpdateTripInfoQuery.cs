namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;

    public class UpdateTripInfoQuery : IRequest<bool>
    {
        public UpdateTripInfoQuery(TripInfoUpdateViewModel tripInfoUpdateViewModel)
        {
            TripInfoUpdateViewModel = tripInfoUpdateViewModel;
        }

        public TripInfoUpdateViewModel TripInfoUpdateViewModel { get; set; }
    }
}
