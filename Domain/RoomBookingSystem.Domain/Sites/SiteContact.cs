namespace RoomBookingSystem.Domain.Sites;

public class SiteContact
{
    public Guid ID { get; set; }
    public Guid SiteId { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public TimeSpan? AvailableFrom { get; set; }
    public TimeSpan? AvailableUntil { get; set; }
}
