using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBookingSystem.Domain.Bookings
{
    [Table("BookingReassignmentReconsideration")]
    public class BookingReassignmentReconsideration
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid BookingReassignmentID { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Reason { get; set; }

        [Required]
        public DateTimeOffset RequestedDate { get; set; }

        public DateTimeOffset? ApprovalDate { get; set; }

        public Guid? ApprovalContactId { get; set; }

        [ForeignKey("BookingReassignmentID")]
        public BookingReassignment? BookingReassignment { get; set; }

        [ForeignKey("ApprovalContactId")]
        public Contacts.Contact? ApprovalContact { get; set; }
    }
}