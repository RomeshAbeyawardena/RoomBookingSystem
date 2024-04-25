namespace RoomBookingSystem.Domain.SubRegions;

public class SubRegion
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Reference { get; set; }
    public Guid RegionId { get; set; }
    public Regions.Region? Region { get; set; }
}
