namespace RoomBookingSystem.Domain.Contacts;

public class Contact
{
    public Guid ID { get; set; }
    public Guid TitleId { get; set; }
    public Guid ContactTypeID { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleNames { get; set; }
    public string? LastName { get; set; }
    public Guid? PrimaryAddressId { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? JobTitle { get; set; }
    public string? Department { get; set; }
    public string? ContactNumber { get; set; }

    public virtual Titles.Title? Title { get; set; }
}
