using RoomBookingSystem.Domain.Addresses;

namespace RoomBookingSystem.Domain.Sites;

public class Site
{
    public Guid ID { get; set; }
    public string? Reference { get; set; }
    public string? Name { get; set; }
    public string? ExternalReference { get; set; }
    public Guid PrimaryAddressId { get; set; }
    public Address? PrimaryAddress { get; set; }
}
