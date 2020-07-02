namespace Booking.Infrastructure.Query
{
    using Booking.Domain.ViewModel;
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class GetTripsQuery : IRequest<List<TripInfoViewModel>>
    {
        public GetTripsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
