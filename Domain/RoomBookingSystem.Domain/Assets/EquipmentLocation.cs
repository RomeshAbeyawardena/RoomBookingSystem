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
        public virtual Equipment? PreviousEquipmentLocation { get; set; }
        public virtual Equipment? Equipment { get; set; }
        public virtual Sites.Site? Site { get; set; }
        public virtual Blocks.Block? Block { get; set; }
        public virtual Areas.Area? Area { get; set; }
    }
}