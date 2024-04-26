using System;

namespace RoomBookingSystem.Domain.Bookings
{
    public class BookingCancellation
    {
        public Guid ID { get; set; }
        public Guid BookingId { get; set; }
        public DateTimeOffset CancellationDate { get; set; }
        public string? CancellationReason { get; set; }
        public Guid? CancelledBy { get; set; }
        public Guid? ApprovedByContactId { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }

        public Booking? Booking { get; set; }
        public Contacts.Contact? CancelledByContact { get; set; }
        public Contacts.Contact? ApprovedByContact { get; set; }
    }
}