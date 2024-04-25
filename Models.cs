using System;
using System.Collections.Generic;

public class Country
{
    public Guid ID { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
}

public class County
{
    public Guid ID { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
}

public class Region
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public Guid CountyId { get; set; }
    public County County { get; set; }
}

public class SubRegion
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public Guid RegionId { get; set; }
    public Region Region { get; set; }
}

public class Address
{
    public Guid ID { get; set; }
    public string BuildingNumber { get; set; }
    public string BuildingName { get; set; }
    public string StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string BlockNumber { get; set; }
    public string BlockName { get; set; }
    public string Town { get; set; }
    public string Locality { get; set; }
    public string Province { get; set; }
    public Guid RegionID { get; set; }
    public Guid SubRegionId { get; set; }
    public string PostalCode { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string What3Words { get; set; }
    public Region Region { get; set; }
    public SubRegion SubRegion { get; set; }
}

public class Site
{
    public Guid ID { get; set; }
    public string Reference { get; set; }
    public string Name { get; set; }
    public string ExternalReference { get; set; }
    public Guid PrimaryAddressId { get; set; }
    public Address PrimaryAddress { get; set; }
}

public class Block
{
    public Guid ID { get; set; }
    public string Reference { get; set; }
    public string Name { get; set; }
    public string ExternalReference { get; set; }
    public float AreaSize { get; set; }
    public Guid SiteId { get; set; }
    public Guid? AddressId { get; set; }
    public Site Site { get; set; }
    public Address Address { get; set; }
}

public class AreaType
{
    public Guid ID { get; set; }
    public string Reference { get; set; }
    public string Name { get; set; }
}

public class Area
{
    public Guid ID { get; set; }
    public string Reference { get; set; }
    public string Name { get; set; }
    public string ExternalReference { get; set; }
    public string Suite { get; set; }
    public Guid? FloorNumber { get; set; }
    public string RoomNumber { get; set; }
    public float AreaSize { get; set; }
    public Guid AreaTypeId { get; set; }
    public Guid BlockId { get; set; }
    public AreaType AreaType { get; set; }
    public Block Block { get; set; }
}

public class Title
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
}

public class ContactType
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
}

public class Contact
{
    public Guid ID { get; set; }
    public Guid TitleId { get; set; }
    public Guid ContactTypeID { get; set; }
    public string FirstName { get; set; }
    public string MiddleNames { get; set; }
    public string LastName { get; set; }
    public Guid? PrimaryAddressId { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string JobTitle { get; set; }
    public string Department { get; set; }
    public string ContactNumber { get; set; }
    public Title Title { get; set; }
    public ContactType ContactType { get; set; }
    public Address PrimaryAddress { get; set; }
}

public class ContactEmail
{
    public Guid ID { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public string EmailAddress { get; set; }
    public bool IsInUse { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public Contact Contact { get; set; }
}

public class ContactPhone
{
    public Guid ID { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsInUse { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public Contact Contact { get; set; }
}

public class ContactAddress
{
    public Guid ID { get; set; }
    public string Alias { get; set; }
    public Guid ContactId { get; set; }
    public Guid AddressId { get; set; }
    public DateTimeOffset? ValidFrom { get; set; }
    public DateTimeOffset? ValidTo { get; set; }
    public Contact Contact { get; set; }
    public Address Address { get; set; }
}

public class SiteContact
{
    public Guid ID { get; set; }
    public Guid SiteId { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public TimeSpan? AvailableFrom { get; set; }
    public TimeSpan? AvailableUntil { get; set; }
    public Site Site { get; set; }
    public Contact Contact { get; set; }
}

public class BlockContact
{
    public Guid ID { get; set; }
    public Guid BlockId { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public TimeSpan? AvailableFrom { get; set; }
    public TimeSpan? AvailableUntil { get; set; }
    public Block Block { get; set; }
    public Contact Contact { get; set; }
}

public class Category
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
}

public class SubCategory
{
    public Guid ID { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public Category Category { get; set; }
}

public class AreaUse
{
    public Guid ID { get; set; }
    public Guid AreaId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public string Description { get; set; }
    public string Reference { get; set; }
    public string ExternalReference { get; set; }
    public Area Area { get; set; }
    public Category Category { get; set; }
    public SubCategory SubCategory { get; set; }
}

public class AreaSubUse
{
    public Guid ID { get; set; }
    public Guid AreaId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public Guid AreaUseId { get; set; }
    public string Description { get; set; }
    public string Reference { get; set; }
    public string ExternalReference { get; set; }
    public Area Area { get; set; }
    public Category Category { get; set; }
    public SubCategory SubCategory { get; set; }
    public AreaUse AreaUse { get; set; }
}

public class BlockUse
{
    public Guid ID { get; set; }
    public Guid BlockId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public string Description { get; set; }
    public string Reference { get; set; }
    public string ExternalReference { get; set; }
    public Block Block { get; set; }
    public Category Category { get; set; }
    public SubCategory SubCategory { get; set; }
}

public class BlockSubUse
{
    public Guid ID { get; set; }
    public Guid BlockId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public Guid BlockUseId { get; set; }
    public string Description { get; set; }
    public string Reference { get; set; }
    public string ExternalReference { get; set; }
    public Block Block { get; set; }
    public Category Category { get; set; }
    public SubCategory SubCategory { get; set; }
    public BlockUse BlockUse { get; set; }
}

public class Booking
{
    public Guid ID { get; set; }
    public DateTimeOffset RequestedStartDate { get; set; }
    public DateTimeOffset RequestedEndDate { get; set; }
    public Guid RequestContactId { get; set; }
    public DateTimeOffset RequestDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovedByContactId { get; set; }
    public string Details { get; set; }
    public Contact RequestContact { get; set; }
    public Contact ApprovedByContact { get; set; }
}

public class SiteBooking
{
    public Guid ID { get; set; }
    public Guid BookingId { get; set; }
    public Guid? SiteId { get; set; }
    public DateTimeOffset RequestedStartDate { get; set; }
    public DateTimeOffset RequestedEndDate { get; set; }
    public Guid RequestContactId { get; set; }
    public DateTimeOffset RequestDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovedByContactId { get; set; }
    public string Notes { get; set; }
    public DateTimeOffset? FulfillmentDate { get; set; }
    public Site Site { get; set; }
    public Booking Booking { get; set; }
    public Contact RequestContact { get; set; }
    public Contact ApprovedByContact { get; set; }
}

public class BlockBooking
{
    public Guid ID { get; set; }
    public Guid BookingId { get; set; }
    public Guid BlockId { get; set; }
    public DateTimeOffset RequestedStartDate { get; set; }
    public DateTimeOffset RequestedEndDate { get; set; }
    public Guid RequestContactId { get; set; }
    public DateTimeOffset RequestDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovedByContactId { get; set; }
    public string Notes { get; set; }
    public DateTimeOffset? FulfillmentDate { get; set; }
    public Block Block { get; set; }
    public Booking Booking { get; set; }
    public Contact RequestContact { get; set; }
    public Contact ApprovedByContact { get; set; }
}

public class AreaBooking
{
    public Guid ID { get; set; }
    public Guid BookingId { get; set; }
    public Guid AreaId { get; set; }
    public DateTimeOffset RequestedStartDate { get; set; }
    public DateTimeOffset RequestedEndDate { get; set; }
    public Guid RequestContactId { get; set; }
    public DateTimeOffset RequestDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovedByContactId { get; set; }
    public string Notes { get; set; }
    public DateTimeOffset? FulfillmentDate { get; set; }
    public Area Area { get; set; }
    public Booking Booking { get; set; }
    public Contact RequestContact { get; set; }
    public Contact ApprovedByContact { get; set; }
}

public class BookingCancellation
{
    public Guid ID { get; set; }
    public Guid BookingId { get; set; }
    public DateTimeOffset CancellationDate { get; set; }
    public string CancellationReason { get; set; }
    public Guid? CancelledBy { get; set; }
    public Guid? ApprovedByContactId { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Booking Booking { get; set; }
    public Contact CancelledByContact { get; set; }
    public Contact ApprovedByContact { get; set; }
}

public class WorkNotice
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Details { get; set; }
    public DateTimeOffset DisplayFrom { get; set; }
    public DateTimeOffset DisplayTo { get; set; }
}

public class SiteRestriction
{
    public Guid ID { get; set; }
    public Guid SiteId { get; set; }
    public DateTimeOffset RestrictionStartDate { get; set; }
    public DateTimeOffset? RestrictionEndDate { get; set; }
    public Guid? ApprovalContactId { get; set; }
    public bool IsPowerAffected { get; set; }
    public bool IsUtilitiesAffected { get; set; }
    public string Notes { get; set; }
    public Guid? WorkNoticeId { get; set; }
    public Site Site { get; set; }
    public WorkNotice WorkNotice { get; set; }
    public Contact ApprovalContact { get; set; }
}

public class BlockRestriction
{
    public Guid ID { get; set; }
    public Guid BlockId { get; set; }
    public DateTimeOffset RestrictionStartDate { get; set; }
    public DateTimeOffset? RestrictionEndDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovalContactId { get; set; }
    public bool IsPowerAffected { get; set; }
    public bool IsUtilitiesAffected { get; set; }
    public string Notes { get; set; }
    public Guid? WorkNoticeId { get; set; }
    public Block Block { get; set; }
    public WorkNotice WorkNotice { get; set; }
    public Contact ApprovalContact { get; set; }
}

public class AreaRestriction
{
    public Guid ID { get; set; }
    public Guid AreaId { get; set; }
    public DateTimeOffset RestrictionStartDate { get; set; }
    public DateTimeOffset? RestrictionEndDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovalContactId { get; set; }
    public bool IsPowerAffected { get; set; }
    public bool IsUtilitiesAffected { get; set; }
    public string Notes { get; set; }
    public Guid? WorkNoticeId { get; set; }
    public Area Area { get; set; }
    public WorkNotice WorkNotice { get; set; }
    public Contact ApprovalContact { get; set; }
}

public class AreaWorkNotice
{
    public Guid ID { get; set; }
    public Guid AreaId { get; set; }
    public Guid WorkNoticeId { get; set; }
    public Area Area { get; set; }
    public WorkNotice WorkNotice { get; set; }
}

public class BlockWorkNotice
{
    public Guid ID { get; set; }
    public Guid BlockId { get; set; }
    public Guid WorkNoticeId { get; set; }
    public Block Block { get; set; }
    public WorkNotice WorkNotice { get; set; }
}

public class SiteWorkNotice
{
    public Guid ID { get; set; }
    public Guid SiteId { get; set; }
    public Guid WorkNoticeId { get; set; }
    public Site Site { get; set; }
    public WorkNotice WorkNotice { get; set; }
}

public class BookingReassignment
{
    public Guid ID { get; set; }
    public string Reason { get; set; }
    public Guid BookingId { get; set; }
    public Guid ReassignmentBookingId { get; set; }
    public DateTimeOffset RequestedDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovalContactId { get; set; }
    public Booking Booking { get; set; }
    public Booking ReassignmentBooking { get; set; }
    public Contact ApprovalContact { get; set; }
}

public class BookingReassignmentReconsideration
{
    public Guid ID { get; set; }
    public Guid BookingReassignmentID { get; set; }
    public string Reason { get; set; }
    public DateTimeOffset RequestedDate { get; set; }
    public DateTimeOffset? ApprovalDate { get; set; }
    public Guid? ApprovalContactId { get; set; }
    public BookingReassignment BookingReassignment { get; set; }
    public Contact ApprovalContact { get; set; }
}
