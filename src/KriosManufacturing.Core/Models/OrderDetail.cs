namespace KriosManufacturing.Core.Models;

public class OrderDetail
{
    public long Id
    {
        get; set;
    }
    public long OrderId
    {
        get; set;
    }
    public long ItemId
    {
        get; set;
    }
    public int Quantity
    {
        get; set;
    }
    public required Order Order
    {
        get; set;
    }
    public required Item Item
    {
        get; set;
    }
}