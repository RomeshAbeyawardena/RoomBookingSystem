namespace RoomBookingSystem.Domain.Contacts;

public class ContactAddress
{
    public Guid ID { get; set; }
    public string? Alias { get; set; }
    public Guid ContactId { get; set; }
    public Guid AddressId { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
