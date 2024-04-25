namespace RoomBookingSystem.Domain.Countries;

public class Country
{
    public Guid ID { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Reference { get; set; }
}
