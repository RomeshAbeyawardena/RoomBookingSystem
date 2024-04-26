using System;

namespace RoomBookingSystem.Domain.Contacts
{
    public class ContactAbsence
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? SignOffDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ApprovedByContactId { get; set; }
        public int? SignedOffByContactId { get; set; }
        public string? Notes { get; set; }
        public string? OutOfOfficeMessage { get; set; }

        public Contact? Contact { get; set; }
        public Contact? ApprovedByContact { get; set; }
        public Contact? SignedOffByContact { get; set; }
    }
}