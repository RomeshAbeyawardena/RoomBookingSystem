using System;

namespace RoomBookingSystem.Domain.Suppliers
{
    public class SupplierContact
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ContactId { get; set; }
        public string? Alias { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual Contacts.Contact? Contact { get; set; }
    }
}