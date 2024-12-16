using System.ComponentModel.DataAnnotations;

namespace KriosManufacturing.Core.Models;

public class Item
{
    public long Id
    {
        get;
        set;
    }

    [Required]
    [StringLength(64)]
    public required string Sku
    {
        get;
        set;
    }

    [Required]
    [StringLength(128)]
    public required string Name
    {
        get;
        set;
    }

    [StringLength(256)]
    public string? Description
    {
        get;
        set;
    }

    private ICollection<InventoryRecord>? InventoryRecords
    {
        get;
        set;
    }
}