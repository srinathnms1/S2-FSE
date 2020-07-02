namespace Booking.Domain
{
    using Types;
    using System;
    using Microservice.Core;

    public class TripInfo: IAuditEntity, IEntity
    {
        public TripInfo BuildTrip(TripInfo tripInfo, Guid driverId)
        {
            tripInfo.Id = Guid.NewGuid();
            tripInfo.CreatedBy = "System";
            tripInfo.CreatedOn = DateTime.Now;
            tripInfo.UpdatedBy= "System";
            tripInfo.UpdatedOn = DateTime.Now;
            tripInfo.StartTime = DateTime.Now;
            tripInfo.Status = TripStatus.ReadyToPick.ToString();
            tripInfo.DriverId = driverId;

            return tripInfo;
        }

        public TripInfo BuildTrip(TripInfo tripInfo)
        {
            tripInfo.UpdatedBy = "System";
            tripInfo.UpdatedOn = DateTime.Now;

            return tripInfo;
        }

        public Guid BookingId { get; set; }

        public Guid DriverId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? CompletedTime { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int NumberOfPassanger { get; set; }

        public decimal? Cost { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public Guid Id { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
