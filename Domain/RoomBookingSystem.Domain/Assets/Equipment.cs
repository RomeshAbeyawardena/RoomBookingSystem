using System;

namespace RoomBookingSystem.Domain.Assets
{
    public class Equipment
    {
        public Guid ID { get; set; }
        public string? Reference { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Barcode { get; set; }
        public string? SerialNumber { get; set; }
        public Guid ClassificationId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public bool IsMobile { get; set; }
        public string? CostCode { get; set; }
        public bool IsPurchased { get; set; }
        public DateTimeOffset? PurchasedDate { get; set; }
        public DateTimeOffset? LastInspectionDate { get; set; }
        public DateTimeOffset? WarrantyEndDate { get; set; }
        public Guid SupplierId { get; set; }
        public Guid? WarrantySupplierId { get; set; }

        public Classifications.Classification? Classification { get; set; }
        public Suppliers.Supplier? Supplier { get; set; }
        public Suppliers.Supplier? WarrantySupplier { get; set; }
    }
}