using RoomBookingSystem.Domain.Addresses;

namespace RoomBookingSystem.Domain.Contacts;

public class ContactAddress
{
    public Guid ID { get; set; }
    public string? Alias { get; set; }
    public Guid ContactId { get; set; }
    public Guid AddressId { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }

    public virtual Contact? Contact { get; set; }
    public virtual Address? Address { get; set; }
}
