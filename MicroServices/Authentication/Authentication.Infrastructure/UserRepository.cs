namespace Authentication.Infrastructure
{
    using Authentication.Domain;
    using Authentication.Domain.Types;
    using Authentication.Infrastracture;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System;

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AuthContext authContext)
        : base(authContext)
        {
        }

        public async Task<Guid> UserRegistration(User user)
        {
            return await Create(user);
        }

        public User GetUser(string username)
        {
            var user = GetAll().Include(i=>i.UserInfo).FirstOrDefault(u => u.Username == username);

            return user;
        }

        public List<User> GetEmployees()
        {
            var employees = GetAll().Include(u=>u.UserInfo).Where(u => u.UserType == UserType.Employee.ToString()).ToList();
            return employees;
        }
    }
}
