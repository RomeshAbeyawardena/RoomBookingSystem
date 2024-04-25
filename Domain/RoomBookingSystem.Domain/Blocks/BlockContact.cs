namespace RoomBookingSystem.Domain.Blocks;

public class BlockContact
{
    public Guid ID { get; set; }
    public Guid BlockId { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public TimeSpan? AvailableFrom { get; set; }
    public TimeSpan? AvailableUntil { get; set; }
}
