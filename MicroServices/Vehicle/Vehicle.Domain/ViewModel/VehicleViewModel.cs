namespace Vehicle.Domain.ViewModel
{
    using System;

    public class VehicleViewModel
    {
        public Guid DriverId { get; set; }

        public string RegistrationNumber { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public int NoOfSeats { get; set; }
    }
}
