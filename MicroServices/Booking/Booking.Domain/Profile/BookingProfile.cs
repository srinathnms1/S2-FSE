namespace Booking.Domain.Profile
{
    using Domain.ViewModel;
    using AutoMapper;

    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingViewModel, Booking>().ReverseMap();

            CreateMap<UpdateBookingViewModel, Booking>();
            CreateMap<UpdateBookingViewModel, TripInfo>();

            CreateMap<AcceptBookingViewModel, Booking>()
                .ForMember(src=>src.Id, opt=>opt.MapFrom(dist=>dist.BookingId));

            CreateMap<TripInfoViewModel, TripInfo>().ReverseMap();

            CreateMap<TripInfoUpdateViewModel, TripInfo>().ReverseMap();

            CreateMap<Booking, TripInfo>()
                .ForMember(src => src.BookingId, opt => opt.MapFrom(dist => dist.Id))
                .ForMember(src => src.StartTime, opt => opt.MapFrom(dist => dist.Date));
        }
    }
}
