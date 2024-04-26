using System;

namespace RoomBookingSystem.Domain.Blocks
{
    public class BlockBooking
    {
        public Guid ID { get; set; }
        public Guid BookingId { get; set; }
        public Guid BlockId { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public Guid? ApprovedByContactId { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset? FulfillmentDate { get; set; }

        // Navigation properties
        public Bookings.Booking? Booking { get; set; }
        public Block? Block { get; set; }
        public Contacts.Contact? ApprovedByContact { get; set; }
    }
}