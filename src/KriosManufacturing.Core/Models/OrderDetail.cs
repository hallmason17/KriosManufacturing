namespace KriosManufacturing.Core.Models;

public class OrderDetail
{
    public long Id
    {
        get;
        set;
    }

    public long OrderId
    {
        get;
        set;
    }

    public long ItemId
    {
        get;
        set;
    }

    public int Quantity
    {
        get;
        set;
    }

    public Order? Order
    {
        get;
        set;
    }

    public Item? Item
    {
        get;
        set;
    }
}