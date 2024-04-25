namespace RoomBookingSystem.Domain.Areas;

public class Area
{
    public Guid ID { get; set; }
    public string? Reference { get; set; }
    public string? Name { get; set; }
    public string? ExternalReference { get; set; }
    public string? Suite { get; set; }
    public Guid? FloorNumber { get; set; }
    public string? RoomNumber { get; set; }
    public double? AreaSize { get; set; }
    public Guid AreaTypeId { get; set; }
    public Guid BlockId { get; set; }
}
