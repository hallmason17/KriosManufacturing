namespace KriosManufacturing.Core.Models;

using System.ComponentModel.DataAnnotations;
public class Location
{
    public long Id
    {
        get;
        set;
    }

    [Required]
    [StringLength(16)]
    required public string Unit
    {
        get;
        set;
    }

    [Required]
    [StringLength(16)]
    required public string Cell
    {
        get;
        set;
    }

    public ICollection<InventoryRecord>? InventoryRecords
    {
        get;
        set;
    }
}