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
    public string Sku
    {
        get;
        set;
    }

    [Required]
    [StringLength(128)]
    public string Name
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