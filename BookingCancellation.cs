using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BookingCancellation
{
    [Key]
    public Guid ID { get; set; }

    [Required]
    public Guid BookingId { get; set; }

    [Required]
    public DateTimeOffset CancellationDate { get; set; }

    public string CancellationReason { get; set; }

    public Guid? CancelledBy { get; set; }

    public Guid? ApprovedByContactId { get; set; }

    public DateTimeOffset? ApprovalDate { get; set; }
}