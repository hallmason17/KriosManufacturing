namespace KriosManufacturing.Core.Models;

using System.ComponentModel.DataAnnotations;
public class Item
{
    public long Id
    {
        get;
        set;
    }

    [Required]
    [StringLength(64)]
    required public string Sku
    {
        get;
        set;
    }

    [Required]
    [StringLength(128)]
    required public string Name
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

    public ICollection<InventoryRecord> InventoryRecords
    { get; } = [];
    public ICollection<Lot> Lots
    { get; } = [];
}