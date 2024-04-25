namespace RoomBookingSystem.Domain.Blocks;

public class Block
{
    public Guid ID { get; set; }
    public string? Reference { get; set; }
    public string? Name { get; set; }
    public string? ExternalReference { get; set; }
    public double? AreaSize { get; set; }
    public Guid SiteId { get; set; }
    public Guid? AddressId { get; set; }

    public Sites.Site? Site { get; set; }
    public Addresses.Address? Address { get; set; }
}
