using System;

namespace RoomBookingSystem.Domain.Clients
{
    public class ClientAddress
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid AddressId { get; set; }
        public string? Alias { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Addresses.Address? Address { get; set; }
    }
}