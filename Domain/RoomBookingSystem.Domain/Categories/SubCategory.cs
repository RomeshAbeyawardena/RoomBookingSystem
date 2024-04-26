namespace RoomBookingSystem.Domain.Categories;

public class SubCategory
{
    public Guid ID { get; set; }
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }

    public virtual Category? Category { get; set; }
}
