using RoomBookingSystem.Domain.Categories;

namespace RoomBookingSystem.Domain.Areas;

public class AreaSubUse
{
    public Guid ID { get; set; }
    public Guid AreaId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public Guid AreaUseId { get; set; }
    public string? Description { get; set; }
    public string? Reference { get; set; }
    public string? ExternalReference { get; set; }

    public Area? Area { get; set; }
    public Category? Category { get; set; }
    public SubCategory? SubCategory { get; set; }
    public AreaUse? AreaUse { get; set; }
}
