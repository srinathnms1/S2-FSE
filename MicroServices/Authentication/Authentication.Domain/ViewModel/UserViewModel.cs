namespace Authentication.Domain.ViewModel
{
    using System;
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string UserType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Mobile { get; set; }

        public string Email { get; set; }

        public string Name => $"{FirstName}, {LastName}";

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdateddBy { get; set; }
    }
}
