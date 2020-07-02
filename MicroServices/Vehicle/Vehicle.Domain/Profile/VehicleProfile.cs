namespace Vehicle.Domain.Profile
{
    using Vehicle.Domain;
    using Vehicle.Domain.ViewModel;
    using AutoMapper;

    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleViewModel, VehicleInfo>()
                .ReverseMap();
        }
    }
}
