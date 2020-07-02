namespace Authentication.Domain
{
    using Microservice.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository : IGenericRepository<User>
    {
        Task<Guid> UserRegistration(User user);

        User GetUser(string username);

        List<User> GetEmployees();
    }
}
