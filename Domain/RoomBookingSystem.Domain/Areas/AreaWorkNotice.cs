using System;

namespace RoomBookingSystem.Domain.Areas
{
    public class AreaWorkNotice
    {
        public Guid ID { get; set; }
        public Guid AreaId { get; set; }
        public Guid WorkNoticeId { get; set; }
        
         public virtual Area? Area { get; set; }
         public virtual WorkNotices.WorkNotice? WorkNotice { get; set; }
    }
}