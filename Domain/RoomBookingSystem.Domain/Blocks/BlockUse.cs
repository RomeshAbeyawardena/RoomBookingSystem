﻿namespace RoomBookingSystem.Domain.Blocks;

public class BlockUse
{
    public Guid ID { get; set; }
    public Guid BlockId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public string? Description { get; set; }
    public string? Reference { get; set; }
    public string? ExternalReference { get; set; }

    public virtual Block? Block { get; set; }
    public virtual Categories.Category? Category { get; set; }
    public virtual Categories.SubCategory? SubCategory { get; set; }
}
