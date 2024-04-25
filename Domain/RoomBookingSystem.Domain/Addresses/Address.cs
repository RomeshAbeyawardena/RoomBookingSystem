namespace RoomBookingSystem.Domain.Addresses;

public class Address
{
    public Guid ID { get; set; }
    public string? BuildingNumber { get; set; }
    public string? BuildingName { get; set; }
    public string? StreetNumber { get; set; }
    public string? StreetName { get; set; }
    public string? BlockNumber { get; set; }
    public string? BlockName { get; set; }
    public string? Town { get; set; }
    public string? Locality { get; set; }
    public string? Province { get; set; }
    public Guid RegionID { get; set; }
    public Guid SubRegionId { get; set; }
    public string? PostalCode { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string? What3Words { get; set; }
}
