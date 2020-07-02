namespace Authentication.Infrastructure.Handler
{
    using Authentication.Domain;
    using Authentication.Domain.ViewModel;
    using Authentication.Infrastructure.Query;
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginHandler : IRequestHandler<GetUserDetailQuery, UserViewModel>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public LoginHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public Task<UserViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = this.userRepository.GetUser(request.LoginViewModel.Username);
            if (user == null)
            {
                return null;
            }
            var passwordHash = new PasswordHash(user.Salt, user.Password);
            if (passwordHash.Verify(request.LoginViewModel.Password))
            {
                var userViewModel = mapper.Map<UserViewModel>(user);
                mapper.Map(user.UserInfo, userViewModel);
                return Task.FromResult(userViewModel);
            }
            return null;
        }
    }
}