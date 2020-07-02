namespace Authentication.Domain.ViewModel
{
    using System;

    public class UserClaim
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public double Mobile { get; set; }

        public string Token { get; set; }

        public string UserType { get; set; }

        public int ExpiresIn { get; set; }
    }
}
