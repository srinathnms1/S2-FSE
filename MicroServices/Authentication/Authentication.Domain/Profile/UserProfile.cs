namespace Authentication.Domain.Profile
{
    using Authentication.Domain;
    using Authentication.Domain.ViewModel;
    using AutoMapper;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationViewModel, User>()
                .ForMember(src => src.Password, opt => opt.Ignore());

            CreateMap<RegistrationViewModel, UserInfo>();

            CreateMap<UserViewModel, UserClaim>();

            CreateMap<User, UserViewModel>()
                .ForMember(src => src.FirstName, opt => opt.MapFrom(src=> src.UserInfo.FirstName))
                .ForMember(src => src.LastName, opt => opt.MapFrom(src => src.UserInfo.LastName))
                .ForMember(src => src.Mobile, opt => opt.MapFrom(src => src.UserInfo.Mobile))
                .ForMember(src => src.Email, opt => opt.MapFrom(src => src.UserInfo.Email));

            CreateMap<UserInfo, UserViewModel>();
        }
    }
}
