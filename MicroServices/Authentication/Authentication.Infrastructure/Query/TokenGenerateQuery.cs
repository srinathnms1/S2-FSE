namespace Authentication.Infrastructure.Query
{
    using Authentication.Domain.ViewModel;
    using MediatR;

    public class TokenGenerateQuery : IRequest<UserClaim>
    {
        public TokenGenerateQuery(UserViewModel userViewModel)
        {
            UserViewModel = userViewModel;
        }

        public UserViewModel UserViewModel { get; }
    }

}
