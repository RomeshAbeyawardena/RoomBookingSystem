namespace RoomBookingSystem.Domain.Counties;

public class County
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Reference { get; set; }
    public Guid CountryId { get; set; }
    public Countries.Country? Country { get; set; }
}
