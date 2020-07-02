namespace Authentication.Api.Controllers
{
    using Authentication.Infrastructure.Query;
    using Authentication.Domain.ViewModel;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/authentication
        [HttpPost, Route("")]
        public async Task<UserClaim> Post([FromBody] LoginViewModel loginViewModel)
        {
            var user = await mediator.Send(new GetUserDetailQuery(loginViewModel));
            var userClaim = await mediator.Send(new TokenGenerateQuery(user));

            return userClaim;
        }
    }
}