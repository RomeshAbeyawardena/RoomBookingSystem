using System;

namespace RoomBookingSystem.Domain.Bookings
{
    public class BookingReassignment
    {
        public Guid ID { get; set; }
        public string? Reason { get; set; }
        public Guid BookingId { get; set; }
        public Guid ReassignmentBookingId { get; set; }
        public DateTimeOffset RequestedDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public Guid? ApprovalContactId { get; set; }

        public Booking? Booking { get; set; }
        public Booking? ReassignmentBooking { get; set; }
        public Contacts.Contact? ApprovalContact { get; set; }
    }
}