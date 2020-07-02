namespace Authentication.Domain
{
    using Microservice.Core;
    using System;

    public class User : IEntity, IAuditEntity
    {
        public User BuildUser(string password)
        {
            Id = Guid.NewGuid();
            CreatedBy = UpdatedBy = "System";
            CreatedOn = UpdatedOn = DateTime.Now;
            var passwordHash = new PasswordHash(password);
            Password = passwordHash.Hash;
            Salt = passwordHash.Salt;
            Status = true;
            return this;
        }

        public Guid Id { get; set; }

        public string Username { get; set; }

        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }

        public string UserType { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
