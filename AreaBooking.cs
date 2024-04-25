using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AreaBooking
{
    [Key]
    public Guid ID { get; set; }

    [Required]
    public Guid BookingId { get; set; }

    [Required]
    public Guid AreaId { get; set; }

    [Required]
    public DateTimeOffset RequestDate { get; set; }

    public Guid? ApprovedByContactId { get; set; }

    public DateTimeOffset? ApprovalDate { get; set; }

    public string Notes { get; set; }

    public DateTimeOffset? FulfillmentDate { get; set; }
}