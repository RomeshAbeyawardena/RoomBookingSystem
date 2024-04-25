using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SiteRestriction
{
    [Key]
    public Guid ID { get; set; }

    [Required]
    public Guid SiteId { get; set; }

    [Required]
    public DateTimeOffset RestrictionStartDate { get; set; }

    public DateTimeOffset? RestrictionEndDate { get; set; }

    public Guid? ApprovalContactId { get; set; }
}