using System;

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
}

public class Region
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public Guid CountyId { get; set; }
}

public class SubRegion
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public Guid RegionId { get; set; }
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
}

public class Site
{
    public Guid ID { get; set; }
    public string Reference { get; set; }
    public string Name { get; set; }
    public string ExternalReference { get; set; }
    public Guid PrimaryAddressId { get; set; }
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
    public Guid PrimaryAddressId { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string JobTitle { get; set; }
    public string Department { get; set; }
    public string ContactNumber { get; set; }
}

public class ContactEmail
{
    public Guid ID { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public string EmailAddress { get; set; }
    public bool IsInUse { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}

public class ContactPhone
{
    public Guid ID { get; set; }
    public Guid ContactId { get; set; }
    public string Alias { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsInUse { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}

public class ContactAddress
{
    public Guid ID { get; set; }
    public string Alias { get; set; }
    public Guid ContactId { get; set; }
    public Guid AddressId { get; set; }
    the DateTime? ValidFrom { get; set; }
    the DateTime? ValidTo { get; set; }
}
