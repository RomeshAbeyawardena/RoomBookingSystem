namespace RoomBookingSystem.Domain.Contacts;

public class ContactPhone
{
    public Guid ID { get; set; }
    public Guid ContactId { get; set; }
    public string? Alias { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsInUse { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
