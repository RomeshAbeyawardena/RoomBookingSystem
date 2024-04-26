using System;

namespace RoomBookingSystem.Domain.Suppliers
{
    public class SupplierAddress
    {
        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public Guid AddressId { get; set; }
        public string? Alias { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual Addresses.Address? Address { get; set; }
    }
}