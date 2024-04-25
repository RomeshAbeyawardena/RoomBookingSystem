CREATE TABLE Country (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Country PRIMARY KEY,
    Code CHAR(3) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    Reference NVARCHAR(100) NOT NULL
);

CREATE TABLE County (
    ID UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_County PRIMARY KEY,
    Code CHAR(3) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    Reference NVARCHAR(100) NOT NULL,
    CountryId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (CountryId) REFERENCES Country(ID)
);

CREATE TABLE Region (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Region PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    Reference NVARCHAR(100) NOT NULL,
    CountyId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (CountyId) REFERENCES County(ID)
);

CREATE TABLE SubRegion (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_SubRegion PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    Reference NVARCHAR(100) NOT NULL,
    RegionId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (RegionId) REFERENCES Region(ID)
);

CREATE TABLE Address (
    ID UNIQUEIDENTIFIER 
        CONSTRAINT PK_Address PRIMARY KEY,
    BuildingNumber NVARCHAR(50),
    BuildingName NVARCHAR(100),
    StreetNumber NVARCHAR(50),
    StreetName NVARCHAR(100),
    BlockNumber NVARCHAR(50),
    BlockName NVARCHAR(100),
    Town NVARCHAR(100) NOT NULL,
    Locality NVARCHAR(100),
    Province NVARCHAR(100),
    RegionID UNIQUEIDENTIFIER NOT NULL,
    SubRegionId UNIQUEIDENTIFIER NOT NULL,
    PostalCode CHAR(10) NOT NULL,
    Latitude DECIMAL(9,6) NULL,
    Longitude DECIMAL(9,6) NULL,
    What3Words VARCHAR(100) NULL,
    FOREIGN KEY (RegionID) REFERENCES Region(ID),
    FOREIGN KEY (SubRegionId) REFERENCES SubRegion(ID)
);

CREATE TABLE Site (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Site PRIMARY KEY,
    Reference NVARCHAR(100) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    ExternalReference NVARCHAR(100),
    PrimaryAddressId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (PrimaryAddressId) REFERENCES Address(ID)
);

CREATE TABLE Block (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Block PRIMARY KEY,
    Reference NVARCHAR(100) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    ExternalReference NVARCHAR(100),
    AreaSize FLOAT,
    SiteId UNIQUEIDENTIFIER NOT NULL,
    AddressId UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (AddressId) REFERENCES Address(ID)
);

CREATE TABLE AreaType (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_AreaType PRIMARY KEY,    
    Reference NVARCHAR(100) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL
);

CREATE TABLE Area (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Area PRIMARY KEY,
    Reference NVARCHAR(100) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    ExternalReference NVARCHAR(100),
    Suite VARCHAR(50) NULL,
    FloorNumber UNIQUEIDENTIFIER NULL,
    RoomNumber VARCHAR(50) NULL,
    AreaSize FLOAT,
    AreaTypeId UNIQUEIDENTIFIER NOT NULL,
    BlockId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (AreaTypeId) REFERENCES AreaType(ID),
    FOREIGN KEY (BlockId) REFERENCES Block(ID)
);

CREATE TABLE Title (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Title PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    DisplayName NVARCHAR(100)
);

CREATE TABLE ContactType (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_ContactType PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    DisplayName NVARCHAR(100)
);

CREATE TABLE Contact (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Contact PRIMARY KEY,
    TitleId UNIQUEIDENTIFIER NOT NULL,
    ContactTypeID UNIQUEIDENTIFIER NOT NULL,
    FirstName NVARCHAR(100) NOT NULL,
    MiddleNames NVARCHAR(100) NULL,
    LastName NVARCHAR(100) NOT NULL,
    PrimaryAddressId UNIQUEIDENTIFIER,
    DATETIMEOFFSETOfBirth DATETIMEOFFSET NOT NULL,
    JobTitle NVARCHAR(100) NULL,
    Department NVARCHAR(100) NULL,
    ContactNumber NVARCHAR(50),
    FOREIGN KEY (TitleId) REFERENCES Title(ID),
    FOREIGN KEY (ContactTypeID) REFERENCES ContactType(ID),
    FOREIGN KEY (PrimaryAddressId) REFERENCES Address(ID)
);

CREATE TABLE ContactEmail (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_ContactEmail PRIMARY KEY,
    ContactId UNIQUEIDENTIFIER NOT NULL,
    Alias NVARCHAR(100) NOT NULL,
    EmailAddress NVARCHAR(255) NOT NULL,
    IsInUse BIT,
    ValidFrom DATETIMEOFFSET NULL,
    ValidTo DATETIMEOFFSET NULL,
    FOREIGN KEY (ContactId) REFERENCES Contact(ID)
);

CREATE TABLE ContactPhone (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_ContactPhone PRIMARY KEY,
    ContactId UNIQUEIDENTIFIER NOT NULL,
    Alias NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    IsInUse BIT,
    ValidFrom DATETIMEOFFSET NULL,
    ValidTo DATETIMEOFFSET NULL,
    FOREIGN KEY (ContactId) REFERENCES Contact(ID)
);

CREATE TABLE ContactAddress (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_ContactAddress PRIMARY KEY,
    Alias NVARCHAR(100) NOT NULL,
    ContactId UNIQUEIDENTIFIER NOT NULL,
    AddressId UNIQUEIDENTIFIER NOT NULL,
    ValidFrom DATETIMEOFFSET NULL,
    ValidTo DATETIMEOFFSET NULL,
    FOREIGN KEY (ContactId) REFERENCES Contact(ID),
    FOREIGN KEY (AddressId) REFERENCES Address(ID)
);

CREATE TABLE SiteContact (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_SiteContact PRIMARY KEY,
    SiteId UNIQUEIDENTIFIER NOT NULL,
    ContactId UNIQUEIDENTIFIER NOT NULL,
    Alias NVARCHAR(100) NOT NULL,
    AvailableFrom TIME NULL, -- e.g. 9am Supported in SQL Server 2016 and higher
    AvailableUntil TIME NULL, -- e.g. 5.30pm Supported in SQL Server 2016 and higher
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (ContactId) REFERENCES Contact(ID),
    UNIQUE (SiteId, ContactId, Alias) -- Ensures that each alias is unique per site
);

CREATE TABLE BlockContact (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BlockContact PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER NOT NULL,
    ContactId UNIQUEIDENTIFIER NOT NULL,
    Alias NVARCHAR(100) NOT NULL,
    AvailableFrom TIME NULL, -- e.g. 9am Supported in SQL Server 2016 and higher
    AvailableUntil TIME NULL, -- e.g. 5.30pm Supported in SQL Server 2016 and higher
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (ContactId) REFERENCES Contact(ID),
    UNIQUE (BlockId, ContactId, Alias) -- Ensures that each alias is unique per block
);

CREATE TABLE Category (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Category PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    DisplayName NVARCHAR(100)
);

CREATE TABLE SubCategory (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_SubCategory PRIMARY KEY,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    DisplayName NVARCHAR(100),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID)
);

CREATE TABLE AreaUse (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_AreaUse PRIMARY KEY,
    AreaId UNIQUEIDENTIFIER NOT NULL,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    SubCategoryId UNIQUEIDENTIFIER,
    [Description] NVARCHAR(255),
    Reference NVARCHAR(100) NOT NULL,
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID)
);

CREATE TABLE AreaSubUse (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_AreaSubuse PRIMARY KEY,
    AreaId UNIQUEIDENTIFIER NOT NULL,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    SubCategoryId UNIQUEIDENTIFIER,
    AreaUseId UNIQUEIDENTIFIER NOT NULL,
    [Description] NVARCHAR(255),
    Reference NVARCHAR(100) NOT NULL,
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID),
    FOREIGN KEY (AreaUseId) REFERENCES AreaUse(ID)
);

CREATE TABLE BlockUse (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BlockUse PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER NOT NULL,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    SubCategoryId UNIQUEIDENTIFIER,
    [Description] NVARCHAR(255) NULL,
    Reference NVARCHAR(100) NOT NULL,
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID)
);


CREATE TABLE BlockSubUse (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BlockSubUse PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER NOT NULL,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    SubCategoryId UNIQUEIDENTIFIER,
    BlockUseId UNIQUEIDENTIFIER NOT NULL,
    Description NVARCHAR(255),
    Reference NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID),
    FOREIGN KEY (BlockUseId) REFERENCES BlockUse(ID)
);

CREATE TABLE Client (
    ID UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_Client PRIMARY KEY,
    Reference NVARCHAR(100) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    ExternalReference NVARCHAR(100),
    PrimaryAddressId UNIQUEIDENTIFIER,
    FOREIGN KEY (PrimaryAddressId) REFERENCES Address(ID)
);

CREATE TABLE Booking (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_Booking PRIMARY KEY,
    Reference NVARCHAR(200)
    RequestedStartDate DATETIMEOFFSET NOT NULL,
    RequestedEndDate DATETIMEOFFSET NOT NULL,
    RequestContactId UNIQUEIDENTIFIER NOT NULL,
    ClientId UNIQUEIDENTIFIER NULL,
    RequestDate DATETIMEOFFSET NOT NULL,
    ApprovalDate DATETIMEOFFSET NULL,
    ApprovedByContactId UNIQUEIDENTIFIER NULL,
    Details NVARCHAR(MAX) NULL,
    FOREIGN KEY (RequestContactId) REFERENCES Contact(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID),
    FOREIGN KEY (ClientId) REFERENCES Client(ID)
);


CREATE TABLE BookingCancellation (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BookingCancellation PRIMARY KEY,
    BookingId UNIQUEIDENTIFIER NOT NULL,
    CancellationDate DATETIMEOFFSET NOT NULL,
    CancellationReason NVARCHAR(255),
    CancelledBy UNIQUEIDENTIFIER,
    ApprovedByContactId UNIQUEIDENTIFIER,
    ApprovalDate DATETIMEOFFSET NULL,
    FOREIGN KEY (BookingId) REFERENCES Booking(ID),
    FOREIGN KEY (CancelledBy) REFERENCES Contact(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID)
);

CREATE TABLE SiteBooking (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_SiteBooking PRIMARY KEY,
    BookingId UNIQUEIDENTIFIER NOT NULL,
    SiteId UNIQUEIDENTIFIER,
    RequestDate DATETIMEOFFSET NOT NULL,
    ApprovalDate DATETIMEOFFSET NULL,
    ApprovedByContactId UNIQUEIDENTIFIER,
    Notes NVARCHAR(255) NULL,
    FulfillmentDate DATETIMEOFFSETTIMEOFFSET NULL,
    FOREIGN KEY (BookingId) REFERENCES Booking(ID),
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID)
);

CREATE TABLE BlockBooking (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BlockBooking PRIMARY KEY,
    BookingId UNIQUEIDENTIFIER NOT NULL,
    BlockId UNIQUEIDENTIFIER NOT NULL,
    RequestDate DATETIMEOFFSET NOT NULL,
    ApprovalDate DATETIMEOFFSET NULL,
    ApprovedByContactId UNIQUEIDENTIFIER,
    Notes NVARCHAR(255) NULL,
    FulfillmentDate DATETIMEOFFSETTIMEOFFSET NULL,
     FOREIGN KEY (BookingId) REFERENCES Booking(ID),
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID)
);

CREATE TABLE AreaBooking (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_AreaBooking PRIMARY KEY,
    BookingId UNIQUEIDENTIFIER NOT NULL,
    AreaId UNIQUEIDENTIFIER NOT NULL,
    RequestDate DATETIMEOFFSET NOT NULL,
    ApprovedByContactId UNIQUEIDENTIFIER,
    ApprovalDate DATETIMEOFFSET NULL,
    Notes NVARCHAR(255) NULL,
    FulfillmentDate DATETIMEOFFSETTIMEOFFSET NULL,
    FOREIGN KEY (BookingId) REFERENCES Booking(ID),
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID)
);

CREATE TABLE BookingCancellation (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BookingCancellation PRIMARY KEY,
    BookingId UNIQUEIDENTIFIER NOT NULL,
    CancellationDate DATETIMEOFFSET NOT NULL,
    CancellationReason NVARCHAR(255),
    CancelledBy UNIQUEIDENTIFIER, 
    ApprovedByContactId UNIQUEIDENTIFIER,
    ApprovalDate DATETIMEOFFSET NULL,
    FOREIGN KEY (BookingId) REFERENCES Booking(ID),
    FOREIGN KEY (CancelledBy) REFERENCES Contact(ID)
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID)
);


CREATE TABLE WorkNotice (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_WorkNotice PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Summary NVARCHAR(MAX),
    Details NVARCHAR(MAX),
    DisplayFrom DATETIMEOFFSET NOT NULL,
    DisplayTo DATETIMEOFFSET NOT NULL
);

CREATE TABLE SiteRestriction (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_SiteRestriction PRIMARY KEY,
    SiteId UNIQUEIDENTIFIER NOT NULL,
    RestrictionStartDate DATETIMEOFFSET NOT NULL,
    RestrictionEndDate DATETIMEOFFSET,
    ApprovalContactId UNIQUEIDENTIFIER NULL,
    IsPowerAffected BIT NOT NULL,
    IsUtilitiesAffected BIT NOT NULL,
    Notes NVARCHAR(2000) NULL,
    WorkNoticeId UNIQUEIDENTIFIER NULL
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID),
    FOREIGN KEY (WorkNoticeId) REFERENCES WorkNotice(ID)
);

CREATE TABLE BlockRestriction (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BlockRestriction PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER NOT NULL,
    RestrictionStartDate DATETIMEOFFSET NOT NULL,
    RestrictionEndDate DATETIMEOFFSET,
    ApprovalDate DATETIMEOFFSET NULL,
    ApprovalContactId UNIQUEIDENTIFIER,
    IsPowerAffected BIT NOT NULL,
    IsUtilitiesAffected BIT NOT NULL,
    Notes NVARCHAR(2000),
    WorkNoticeId UNIQUEIDENTIFIER NULL
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID),
    FOREIGN KEY (WorkNoticeId) REFERENCES WorkNotice(ID)
);

CREATE TABLE AreaRestriction (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_AreaRestriction PRIMARY KEY,
    AreaId UNIQUEIDENTIFIER NOT NULL,
    RestrictionStartDate DATETIMEOFFSET NOT NULL,
    RestrictionEndDate DATETIMEOFFSET,
    ApprovalDate DATETIMEOFFSET,
    ApprovalContactId UNIQUEIDENTIFIER,
    IsPowerAffected BIT NOT NULL,
    IsUtilitiesAffected BIT NOT NULL,
    Notes NVARCHAR(2000),
    WorkNoticeId UNIQUEIDENTIFIER NULL
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (ApprovedByContactId) REFERENCES Contact(ID),
    FOREIGN KEY (WorkNoticeId) REFERENCES WorkNotice(ID)
);

CREATE TABLE AreaWorkNotice (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_AreaWorkNotice PRIMARY KEY,
    AreaId UNIQUEIDENTIFIER NOT NULL,
    WorkNoticeId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (WorkNoticeId) REFERENCES WorkNotice(ID)
);

CREATE TABLE BlockWorkNotice (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BlockWorkNotice PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER NOT NULL,
    WorkNoticeId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (WorkNoticeId) REFERENCES WorkNotice(ID)
);

CREATE TABLE SiteWorkNotice (
    ID UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_SiteWorkNotice PRIMARY KEY,
    SiteId UNIQUEIDENTIFIER NOT NULL,
    WorkNoticeId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (WorkNoticeId) REFERENCES WorkNotice(ID)
);

CREATE TABLE BookingReassignment (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BookingReassignment PRIMARY KEY,
    Reason NVARCHAR(255) NOT NULL,
    BookingId UNIQUEIDENTIFIER NOT NULL,
    ReassignmentBookingId UNIQUEIDENTIFIER NOT NULL,
    RequestedDate DATETIMEOFFSET NOT NULL,
    ApprovalDate DATETIMEOFFSET NULL,
    ApprovalContactId UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (BookingId) REFERENCES Booking(ID),
    FOREIGN KEY (ReassignmentBookingId) REFERENCES Booking(ID),
    FOREIGN KEY (ApprovalContactId) REFERENCES Contact(ID)
);

CREATE TABLE BookingReassignmentReconsideration (
    ID UNIQUEIDENTIFIER NOT NULL 
        CONSTRAINT PK_BookingReassignmentReconsideration PRIMARY KEY,
    BookingReassignmentID UNIQUEIDENTIFIER NOT NULL,
    Reason NVARCHAR(255) NOT NULL,
    RequestedDate DATETIMEOFFSET NOT NULL,
    ApprovalDate DATETIMEOFFSET NULL,
    ApprovalContactId UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (BookingReassignmentID) REFERENCES BookingReassignment(ID),
    FOREIGN KEY (ApprovalContactId) REFERENCES Contact(ID)
);

CREATE TABLE Package (
    ID UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_Package PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

CREATE TABLE PackageClientFee (
    ID UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_PackageClientFee PRIMARY KEY,
    PackageId UNIQUEIDENTIFIER NOT NULL,
    ClientId UNIQUEIDENTIFIER NOT NULL,
    DiscountRate FLOAT NOT NULL,  -- e.g., 0.25 for 25% discount, 1 for 100% discount
    Fee DECIMAL(18, 2) NOT NULL,
    NumberOfBookingsPerTerm INT,
    IsGivenPriority BIT NOT NULL,
    ContractTerms NVARCHAR(2000),
    FOREIGN KEY (PackageId) REFERENCES Package(ID),
    FOREIGN KEY (ClientId) REFERENCES Client(ID)
);

CREATE TABLE ClientBooking (
    ID UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT PK_ClientBookingCost PRIMARY KEY,
    PackageId UNIQUEIDENTIFIER NULL,  -- Optional: relates to Package if the booking is under a specific package
    BookingId UNIQUEIDENTIFIER NOT NULL,
    Deposit DECIMAL NULL,
    Cost DECIMAL(18, 2) NOT NULL,
    IsApproved BIT NOT NULL,
    IsInvoiced BIT NOT NULL,
    IsProRota BIT NOT NULL,
    IsManaged BIT NOT NULL,
    RequestDate DATETIMEOFFSET NOT NULL,
    ApprovalDate DATETIMEOFFSET NULL,
    AdditionalDetails NVARCHAR(1000),
    FOREIGN KEY (PackageId) REFERENCES Package(ID),
    FOREIGN KEY (BookingId) REFERENCES Booking(ID)
);

