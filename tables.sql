CREATE TABLE Country (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Code CHAR(3),
    [Name] NVARCHAR(100),
    Reference NVARCHAR(100)
);

CREATE TABLE County (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Code CHAR(3),
    [Name] NVARCHAR(100),
    Reference NVARCHAR(100),
    CountryId UNIQUEIDENTIFIER,
    FOREIGN KEY (CountryId) REFERENCES Country(ID)
);

CREATE TABLE Region (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] NVARCHAR(100),
    Reference NVARCHAR(100),
    CountyId UNIQUEIDENTIFIER,
    FOREIGN KEY (CountyId) REFERENCES County(ID)
);

CREATE TABLE SubRegion (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] NVARCHAR(100),
    Reference NVARCHAR(100),
    RegionId UNIQUEIDENTIFIER,
    FOREIGN KEY (RegionId) REFERENCES Region(ID)
);

CREATE TABLE Address (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    BuildingNumber NVARCHAR(50),
    BuildingName NVARCHAR(100),
    StreetNumber NVARCHAR(50),
    StreetName NVARCHAR(100),
    BlockNumber NVARCHAR(50),
    BlockName NVARCHAR(100),
    Town NVARCHAR(100),
    Locality NVARCHAR(100),
    Province NVARCHAR(100),
    RegionID UNIQUEIDENTIFIER,
    SubRegionId UNIQUEIDENTIFIER,
    PostalCode CHAR(10),
    Latitude DECIMAL(9,6) NULL,
    Longitude DECIMAL(9,6) NULL,
    What3Words VARCHAR(100) NULL,
    FOREIGN KEY (RegionID) REFERENCES Region(ID),
    FOREIGN KEY (SubRegionId) REFERENCES SubRegion(ID)
);

CREATE TABLE Site (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Reference NVARCHAR(100),
    [Name] NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    PrimaryAddressId UNIQUEIDENTIFIER,
    FOREIGN KEY (PrimaryAddressId) REFERENCES Address(ID)
);

CREATE TABLE Block (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Reference NVARCHAR(100),
    [Name] NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    AreaSize FLOAT,
    SiteId UNIQUEIDENTIFIER,
    AddressId UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (AddressId) REFERENCES Address(ID)
);

CREATE TABLE AreaType (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Reference NVARCHAR(100),
    [Name] NVARCHAR(100)
);

CREATE TABLE Area (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Reference NVARCHAR(100),
    [[Name]] NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    Suite VARCHAR(50) NULL,
    FloorNumber UNIQUEIDENTIFIER NULL,
    RoomNumber VARCHAR(50) NULL,
    AreaSize FLOAT,
    AreaTypeId UNIQUEIDENTIFIER,
    BlockId UNIQUEIDENTIFIER,
    FOREIGN KEY (AreaTypeId) REFERENCES AreaType(ID),
    FOREIGN KEY (BlockId) REFERENCES Block(ID)
);

CREATE TABLE Title (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] NVARCHAR(100),
    DisplayName NVARCHAR(100)
);

CREATE TABLE ContactType (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] NVARCHAR(100),
    DisplayName NVARCHAR(100)
);

CREATE TABLE Contact (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    TitleId UNIQUEIDENTIFIER,
    ContactTypeID UNIQUEIDENTIFIER,
    FirstName NVARCHAR(100),
    MiddleNames NVARCHAR(100) NULL,
    LastName NVARCHAR(100),
    PrimaryAddressId UNIQUEIDENTIFIER,
    DateOfBirth DATE NULL,
    JobTitle NVARCHAR(100) NULL,
    Department NVARCHAR(100) NULL,
    ContactNumber NVARCHAR(50),
    FOREIGN KEY (TitleId) REFERENCES Title(ID),
    FOREIGN KEY (ContactTypeID) REFERENCES ContactType(ID),
    FOREIGN KEY (PrimaryAddressId) REFERENCES Address(ID)
);

CREATE TABLE ContactEmail (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    ContactId UNIQUEIDENTIFIER,
    Alias NVARCHAR(100),
    EmailAddress NVARCHAR(255),
    IsInUse BIT,
    ValidFrom DATE NULL,
    ValidTo DATE NULL,
    FOREIGN KEY (ContactId) REFERENCES Contact(ID)
);

CREATE TABLE ContactPhone (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    ContactId UNIQUEIDENTIFIER,
    Alias NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    IsInUse BIT,
    ValidFrom DATE NULL,
    ValidTo DATE NULL,
    FOREIGN KEY (ContactId) REFERENCES Contact(ID)
);

CREATE TABLE ContactAddress (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Alias NVARCHAR(100),
    ContactId UNIQUEIDENTIFIER,
    AddressId UNIQUEIDENTIFIER,
    ValidFrom DATE NULL,
    ValidTo DATE NULL,
    FOREIGN KEY (ContactId) REFERENCES Contact(ID),
    FOREIGN KEY (AddressId) REFERENCES Address(ID)
);

CREATE TABLE SiteContact (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    SiteId UNIQUEIDENTIFIER,
    ContactId UNIQUEIDENTIFIER,
    Alias NVARCHAR(100),
    AvailableFrom TIME NULL, -- e.g. 9am Supported in SQL Server 2016 and higher
    AvailableUntil TIME NULL, -- e.g. 5.30pm Supported in SQL Server 2016 and higher
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (ContactId) REFERENCES Contact(ID),
    UNIQUE (SiteId, ContactId, Alias) -- Ensures that each alias is unique per site
);

CREATE TABLE BlockContact (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER,
    ContactId UNIQUEIDENTIFIER,
    Alias NVARCHAR(100),
    AvailableFrom TIME NULL, -- e.g. 9am Supported in SQL Server 2016 and higher
    AvailableUntil TIME NULL, -- e.g. 5.30pm Supported in SQL Server 2016 and higher
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (ContactId) REFERENCES Contact(ID),
    UNIQUE (BlockId, ContactId, Alias) -- Ensures that each alias is unique per block
);

CREATE TABLE Category (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    [[Name]] NVARCHAR(100),
    Display[Name] NVARCHAR(100)
);

CREATE TABLE SubCategory (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    CategoryId UNIQUEIDENTIFIER,
    [[Name]] NVARCHAR(100),
    Display[Name] NVARCHAR(100),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID)
);

CREATE TABLE AreaUse (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    AreaId UNIQUEIDENTIFIER,
    CategoryId UNIQUEIDENTIFIER,
    SubCategoryId UNIQUEIDENTIFIER,
    [Description] NVARCHAR(255),
    Reference NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID)
);

CREATE TABLE AreaSubUse (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    AreaId UNIQUEIDENTIFIER,
    CategoryId UNIQUEIDENTIFIER,
    SubCategoryId UNIQUEIDENTIFIER,
    AreaUseId UNIQUEIDENTIFIER,
    [Description] NVARCHAR(255),
    Reference NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID),
    FOREIGN KEY (AreaUseId) REFERENCES AreaUse(ID)
);

CREATE TABLE BlockUse (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER,
    CategoryId UNIQUEIDENTIFIER,
    SubCategoryId UNIQUEIDENTIFIER,
    Description NVARCHAR(255),
    Reference NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID)
);


CREATE TABLE BlockSubUse (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER,
    CategoryId UNIQUEIDENTIFIER,
    SubCategoryId UNIQUEIDENTIFIER,
    BlockUseId UNIQUEIDENTIFIER,
    Description NVARCHAR(255),
    Reference NVARCHAR(100),
    ExternalReference NVARCHAR(100),
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (CategoryId) REFERENCES Category(ID),
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(ID),
    FOREIGN KEY (BlockUseId) REFERENCES BlockUse(ID)
);

CREATE TABLE SiteBooking (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    SiteId UNIQUEIDENTIFIER,
    RequestedStartDate DATETIMEOFFSET,
    RequestedEndDate DATETIMEOFFSET,
    RequestContactId UNIQUEIDENTIFIER,
    RequestCreationDate DATETIMEOFFSET,
    ApprovalDate DATETIMEOFFSET NULL,
    Notes NVARCHAR(255) NULL,
    FulfillmentDate DATETIMEOFFSET NULL,
    FOREIGN KEY (SiteId) REFERENCES Site(ID),
    FOREIGN KEY (RequestContactId) REFERENCES Contact(ID)
);

CREATE TABLE BlockBooking (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    BlockId UNIQUEIDENTIFIER,
    RequestedStartDate DATETIMEOFFSET,
    RequestedEndDate DATETIMEOFFSET,
    RequestContactId UNIQUEIDENTIFIER,
    RequestCreationDate DATETIMEOFFSET,
    ApprovalDate DATETIMEOFFSET NULL,
    Notes NVARCHAR(255) NULL,
    FulfillmentDate DATETIMEOFFSET NULL,
    FOREIGN KEY (BlockId) REFERENCES Block(ID),
    FOREIGN KEY (RequestContactId) REFERENCES Contact(ID)
);

CREATE TABLE AreaBooking (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    AreaId UNIQUEIDENTIFIER,
    RequestedStartDate DATETIMEOFFSET,
    RequestedEndDate DATETIMEOFFSET,
    RequestContactId UNIQUEIDENTIFIER,
    RequestCreationDate DATETIMEOFFSET,
    ApprovalDate DATETIMEOFFSET NULL,
    Notes NVARCHAR(255) NULL,
    FulfillmentDate DATETIMEOFFSET NULL,
    FOREIGN KEY (AreaId) REFERENCES Area(ID),
    FOREIGN KEY (RequestContactId) REFERENCES Contact(ID)
);
