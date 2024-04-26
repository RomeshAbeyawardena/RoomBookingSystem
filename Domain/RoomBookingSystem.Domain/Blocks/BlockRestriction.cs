using System;

namespace RoomBookingSystem.Domain.Blocks
{
    public class BlockRestriction
    {
        public Guid ID { get; set; }
        public Guid BlockId { get; set; }
        public DateTimeOffset RestrictionStartDate { get; set; }
        public DateTimeOffset? RestrictionEndDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public Guid? ApprovalContactId { get; set; }
        public bool IsPowerAffected { get; set; }
        public bool IsUtilitiesAffected { get; set; }
        public string? Notes { get; set; }
        public Guid? WorkNoticeId { get; set; }

        // Navigation properties
        public Block? Block { get; set; }
        public Contacts.Contact? ApprovedByContact { get; set; }
        public WorkNotices.WorkNotice? WorkNotice { get; set; }
    }
}