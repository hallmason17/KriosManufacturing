namespace KriosManufacturing.Core.Models;

public class Location
{
    public long Id
    {
        get; set;
    }

    public required string Unit
    {
        get; set;
    }

    public required string Cell
    {
        get; set;
    }

    public ICollection<InventoryRecord>? InventoryRecords
    {
        get; set;
    }
}