using System;

namespace RoomBookingSystem.Domain.WorkNotices
{
    public class WorkNotice
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Details { get; set; }
        public DateTimeOffset DisplayFrom { get; set; }
        public DateTimeOffset? DisplayTo { get; set; }
    }
}