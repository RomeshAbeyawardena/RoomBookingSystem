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

        public virtual Booking? Booking { get; set; }
        public virtual Contacts.Contact? CancelledByContact { get; set; }
        public virtual Contacts.Contact? ApprovedByContact { get; set; }
    }
}