namespace Authentication.Infrastracture
{
    using Authentication.Domain;
    using Microsoft.EntityFrameworkCore;

    public class AuthContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        public AuthContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        }
    }
}
