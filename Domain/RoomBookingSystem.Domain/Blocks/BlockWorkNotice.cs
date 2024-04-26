using System;

namespace RoomBookingSystem.Domain.Blocks
{
    public class BlockWorkNotice
    {
        public Guid ID { get; set; }
        public Guid BlockId { get; set; }
        public Guid WorkNoticeId { get; set; }

        public virtual Block? Block { get; set; }
        public virtual WorkNotices.WorkNotice? WorkNotice { get; set; }
    }
}