using System;

namespace RoomBookingSystem.Domain.Clients
{
    public class ClientBooking
    {
        public Guid ID { get; set; }
        public Guid? PackageId { get; set; }
        public Guid BookingId { get; set; }
        public decimal? Deposit { get; set; }
        public decimal Cost { get; set; }
        public bool IsApproved { get; set; }
        public bool IsInvoiced { get; set; }
        public bool IsProRota { get; set; }
        public bool IsManaged { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public string? AdditionalDetails { get; set; }

        // Navigation properties
        public virtual Packages.Package? Package { get; set; }
        public virtual Bookings.Booking? Booking { get; set; }
    }
}