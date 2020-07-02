namespace Authentication.Infrastructure.Query
{
    using Authentication.Domain.ViewModel;
    using MediatR;

    public class GetUserDetailQuery : IRequest<UserViewModel>
    {
        public GetUserDetailQuery(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public LoginViewModel LoginViewModel { get; }
    }

}
