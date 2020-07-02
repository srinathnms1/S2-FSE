namespace Authentication.Domain.ViewModel
{
    using System;

    public class UserInfoViewModel
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Status { get; set; }
    }
}
