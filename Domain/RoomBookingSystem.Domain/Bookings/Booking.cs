using System;

namespace RoomBookingSystem.Domain.Bookings
{
    public class Booking
    {
        public Guid ID { get; set; }
        public string? Reference { get; set; }
        public DateTimeOffset RequestedStartDate { get; set; }
        public DateTimeOffset RequestedEndDate { get; set; }
        public Guid RequestContactId { get; set; }
        public Guid? ClientId { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public Guid? ApprovedByContactId { get; set; }
        public string? Details { get; set; }

        // Navigation properties
        public virtual Contacts.Contact? RequestContact { get; set; }
        public virtual Contacts.Contact? ApprovedByContact { get; set; }
        public virtual Clients.Client? Client { get; set; }
    }
}