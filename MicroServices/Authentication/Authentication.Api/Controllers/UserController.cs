namespace Authentication.Api.Controllers
{
    using Authentication.Infrastructure.Query;
    using Authentication.Domain.ViewModel;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;

    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // POST api/user/registration
        [HttpPost, Route("registration")]
        public async Task<Guid> Post([FromBody] RegistrationViewModel registrationViewModel)
        {
            var userId = await mediator.Send(new RegistrationQuery(registrationViewModel));

            return userId;
        }

        // GET api/user/employees
        [Authorize]
        [HttpGet, Route("employees")]
        public async Task<IEnumerable<UserViewModel>> Get()
        {
            var employees = await mediator.Send(new GetEmployeesQuery());

            return employees;
        }
    }
}