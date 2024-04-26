using System;

namespace RoomBookingSystem.Domain.Classifications
{
    public class Classification
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public Guid? ParentClassificationId { get; set; }
        public Classification? ParentClassification { get; set; }
    }
}