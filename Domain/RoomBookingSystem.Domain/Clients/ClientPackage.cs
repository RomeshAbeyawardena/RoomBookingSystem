using System;

namespace RoomBookingSystem.Domain.Clients
{
    public class ClientPackage
    {
        public Guid ID { get; set; }
        public Guid PackageId { get; set; }
        public Guid ClientId { get; set; }
        public float DiscountRate { get; set; }
        public decimal Fee { get; set; }
        public DateTimeOffset? RenewalDate { get; set; }
        public int? MaximumBookingsPerTerm { get; set; }
        public bool IsGivenPriority { get; set; }
        public string? ContractTerms { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Packages.Package? Package { get; set; }
    }
}