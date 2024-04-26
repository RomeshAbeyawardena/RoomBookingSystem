using System;

namespace RoomBookingSystem.Domain.Sites
{
    public class SiteRestriction
    {
        public Guid ID { get; set; }
        public Guid SiteId { get; set; }
        public DateTimeOffset RestrictionStartDate { get; set; }
        public DateTimeOffset? RestrictionEndDate { get; set; }
        public Guid? ApprovalContactId { get; set; }
        public bool IsPowerAffected { get; set; }
        public bool IsUtilitiesAffected { get; set; }
        public string? Notes { get; set; }
        public Guid? WorkNoticeId { get; set; }

        // Navigation properties
        public virtual Site? Site { get; set; }
        public virtual Contacts.Contact? ApprovedByContact { get; set; }
        public virtual WorkNotices.WorkNotice? WorkNotice { get; set; }
    }
}