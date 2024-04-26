using System;

namespace RoomBookingSystem.Domain.Classifications
{
    public class Classification
    {
        public Guid ID { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SubCategoryId {get;set;}
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public Guid? ParentClassificationId { get; set; }
        public virtual Classification? ParentClassification { get; set; }

        public virtual Categories.Category? Category { get; set; }
        public virtual Categories.SubCategory? SubCategory { get; set; }
    }
}