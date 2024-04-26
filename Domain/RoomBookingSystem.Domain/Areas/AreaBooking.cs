using System;

namespace RoomBookingSystem.Domain.Areas
{
    public class AreaBooking
    {
        public Guid ID { get; set; }
        public Guid BookingId { get; set; }
        public Guid AreaId { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public Guid? ApprovedByContactId { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset? FulfillmentDate { get; set; }

        // Navigation properties
        public virtual Bookings.Booking? Booking { get; set; }
        public virtual Area? Area { get; set; }
        public virtual Contacts.Contact? ApprovedByContact { get; set; }
    }
}