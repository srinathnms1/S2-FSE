namespace Authentication.Domain
{
    using System;

    public class UserInfo
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }
}
