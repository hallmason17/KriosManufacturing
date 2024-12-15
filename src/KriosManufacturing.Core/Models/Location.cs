using System.ComponentModel.DataAnnotations;

namespace KriosManufacturing.Core.Models;

public class Location
{
    public long Id
    {
        get; set;
    }

    [Required]
    [StringLength(16)]
    public required string Unit
    {
        get; set;
    }

    [Required]
    [StringLength(16)]
    public required string Cell
    {
        get; set;
    }

    public ICollection<InventoryRecord>? InventoryRecords
    {
        get; set;
    }
}