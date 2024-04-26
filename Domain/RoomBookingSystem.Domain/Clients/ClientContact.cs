using System;

namespace RoomBookingSystem.Domain.Clients
{
    public class ClientContact
    {
        public Guid ClientId { get; set; }
        public Guid ContactId { get; set; }
        public string? Alias { get; set; }
        public string? Reference { get; set; }
        public TimeSpan? AvailableFrom { get; set; }
        public TimeSpan? AvailableTo { get; set; }
        public bool IsRequiredOnSite { get; set; }

        // Navigation properties
        public virtual Client? Client { get; set; }
        public virtual Contacts.Contact? Contact { get; set; }
    }
}