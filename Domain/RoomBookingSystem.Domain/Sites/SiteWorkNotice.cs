using System;

namespace RoomBookingSystem.Domain.Sites
{
    public class SiteWorkNotice
    {
        public Guid ID { get; set; }
        public Guid SiteId { get; set; }
        public Guid WorkNoticeId { get; set; }
        
        // Add any additional properties or methods as needed
        
        // You can also define navigation properties for the foreign keys if required
        public virtual Site? Site { get; set; }
        public virtual WorkNotices.WorkNotice? WorkNotice { get; set; }
    }
}