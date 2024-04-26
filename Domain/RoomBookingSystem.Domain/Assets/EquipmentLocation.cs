using System;

namespace RoomBookingSystem.Domain.Assets
{
    public class EquipmentLocation
    {
        public Guid ID { get; set; }
        public Guid? PreviousEquipmentLocationId { get; set; }
        public string? Reference { get; set; }
        public Guid EquipmentId { get; set; }
        public Guid? SiteId { get; set; }
        public Guid? BlockId { get; set; }
        public Guid? AreaId { get; set; }
        public bool IsLocated { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Verified { get; set; }

        // Navigation properties
        public Equipment? PreviousEquipmentLocation { get; set; }
        public Equipment? Equipment { get; set; }
        public Sites.Site? Site { get; set; }
        public Blocks.Block? Block { get; set; }
        public Areas.Area? Area { get; set; }
    }
}