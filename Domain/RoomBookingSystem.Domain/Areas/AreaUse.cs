namespace RoomBookingSystem.Domain.Areas;

public class AreaUse
{
    public Guid ID { get; set; }
    public Guid AreaId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public string? Description { get; set; }
    public string? Reference { get; set; }
    public string? ExternalReference { get; set; }

    public virtual Area? Area { get; set; }
    public virtual Categories.Category? Category { get; set; }
    public virtual Categories.SubCategory? SubCategory { get; set; }
}
