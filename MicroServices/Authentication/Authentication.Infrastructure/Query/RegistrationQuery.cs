namespace Authentication.Infrastructure.Query
{
    using Authentication.Domain.ViewModel;
    using MediatR;
    using System;

    public class RegistrationQuery : IRequest<Guid>
    {
        public RegistrationQuery(RegistrationViewModel registrationViewModel)
        {
            RegistrationViewModel = registrationViewModel;
        }

        public RegistrationViewModel RegistrationViewModel { get; }
    }

}
