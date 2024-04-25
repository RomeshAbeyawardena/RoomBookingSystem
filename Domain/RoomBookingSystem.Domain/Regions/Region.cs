namespace RoomBookingSystem.Domain.Regions;

public class Region
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Reference { get; set; }
    public Guid CountyId { get; set; }
    public Counties.County? County { get; set; }
}
