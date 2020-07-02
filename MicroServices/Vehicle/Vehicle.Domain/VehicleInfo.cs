namespace Vehicle.Domain
{
    using System;
    using Microservice.Core;

    public class VehicleInfo : IEntity, IAuditEntity
    {
        public VehicleInfo BuildVehicleInfo()
        {
            Id = Guid.NewGuid();
            CreatedBy = UpdatedBy = "System";
            CreatedOn = UpdatedOn = DateTime.Now;
            return this;
        }

        public Guid Id { get; set; }

        public Guid DriverId { get; set; }

        public string RegistrationNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int NoOfSeats { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
