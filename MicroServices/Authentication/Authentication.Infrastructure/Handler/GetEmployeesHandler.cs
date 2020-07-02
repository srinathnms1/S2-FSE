namespace Authentication.Infrastructure.Handler
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Authentication.Infrastructure.Query;
    using Authentication.Domain.ViewModel;
    using MediatR;
    using AutoMapper;
    using Authentication.Domain;

    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<UserViewModel>>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public GetEmployeesHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        public Task<List<UserViewModel>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = this.userRepository.GetEmployees();
            var userViewModels = this.mapper.Map<List<UserViewModel>>(employees);

            return Task.Run(() => userViewModels);
        }
    }
}