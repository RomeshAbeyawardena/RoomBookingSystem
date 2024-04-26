using System;

namespace RoomBookingSystem.Domain.Clients
{
    public class Client
    {
        public Guid ID { get; set; }
        public string? Reference { get; set; }
        public string? Name { get; set; }
        public string? ExternalReference { get; set; }
        public Guid? PrimaryAddressId { get; set; }
        public virtual Addresses.Address? PrimaryAddress { get; set; }
    }
}