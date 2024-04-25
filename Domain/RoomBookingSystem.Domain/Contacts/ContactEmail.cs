namespace RoomBookingSystem.Domain.Contacts;

public class ContactEmail
{
    public Guid ID { get; set; }
    public Guid ContactId { get; set; }
    public string? Alias { get; set; }
    public string? EmailAddress { get; set; }
    public bool IsInUse { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
}
