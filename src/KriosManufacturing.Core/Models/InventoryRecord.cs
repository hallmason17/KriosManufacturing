namespace KriosManufacturing.Core.Models;

public class InventoryRecord
{
    public long Id
    {
        get;
        set;
    }

    public long ItemId
    {
        get;
        set;
    }

    public long LocationId
    {
        get;
        set;
    }

    public long LotId
    {
        get;
        set;
    }

    public int Quantity
    {
        get;
        set;
    }

    public required Item Item
    {
        get;
        set;
    }

    public required Location Location
    {
        get;
        set;
    }

    public required Lot Lot
    {
        get;
        set;
    }
}