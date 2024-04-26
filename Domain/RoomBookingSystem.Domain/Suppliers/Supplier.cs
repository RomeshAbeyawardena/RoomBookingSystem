using System;

namespace RoomBookingSystem.Domain.Suppliers
{
    public class Supplier
    {
        public Guid ID { get; set; }
        public string? Reference { get; set; }
        public string? Name { get; set; }
        public string? ExternalReference { get; set; }
        public string? CostCode { get; set; }
    }
}