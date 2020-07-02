namespace Authentication.Infrastructure.Query
{
    using Authentication.Domain.ViewModel;
    using MediatR;
    using System.Collections.Generic;

    public class GetEmployeesQuery : IRequest<List<UserViewModel>>
    {
    }
}
