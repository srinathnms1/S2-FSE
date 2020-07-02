namespace Authentication.Infrastructure.Handler
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Authentication.Domain;
    using Authentication.Infrastructure.Query;
    using AutoMapper;
    using MediatR;

    public class RegistrationHandler : IRequestHandler<RegistrationQuery, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public RegistrationHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public Task<Guid> Handle(RegistrationQuery request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request.RegistrationViewModel);
            var userInfo = mapper.Map<UserInfo>(request.RegistrationViewModel);
            user.BuildUser(request.RegistrationViewModel.Password);
            user.UserInfo = userInfo;
            userInfo.UserId = user.Id;

            return this.userRepository.Create(user);
        }
    }
}