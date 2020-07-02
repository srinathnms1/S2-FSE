namespace Microservice.Core
{
    using System;
    public interface IAuditEntity
    {
        DateTime CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTime UpdatedOn { get; set; }

        string UpdatedBy { get; set; }
    }
}
