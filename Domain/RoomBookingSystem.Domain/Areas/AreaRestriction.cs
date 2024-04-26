using System;

namespace RoomBookingSystem.Domain.Areas
{
    public class AreaRestriction
    {
        public Guid ID { get; set; }
        public Guid AreaId { get; set; }
        public DateTimeOffset RestrictionStartDate { get; set; }
        public DateTimeOffset? RestrictionEndDate { get; set; }
        public DateTimeOffset? ApprovalDate { get; set; }
        public Guid? ApprovalContactId { get; set; }
        public bool IsPowerAffected { get; set; }
        public bool IsUtilitiesAffected { get; set; }
        public string? Notes { get; set; }
        public Guid? WorkNoticeId { get; set; }

        public Area? Area { get; set; }
        public Contacts.Contact? ApprovedByContact { get; set; }
        public WorkNotices.WorkNotice? WorkNotice { get; set; }
    }
}