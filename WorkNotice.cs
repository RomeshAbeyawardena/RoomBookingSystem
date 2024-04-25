using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class WorkNotice
{
    [Key]
    public Guid ID { get; set; }

    [Required]
    public string Title { get; set; }

    public string Summary { get; set; }

    public string Details { get; set; }

    [Required]
    public DateTimeOffset DisplayFrom { get; set; }

    [Required]
    public DateTimeOffset DisplayTo { get; set; }
}