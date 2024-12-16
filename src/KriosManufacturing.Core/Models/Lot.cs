namespace KriosManufacturing.Core.Models;

using System.ComponentModel.DataAnnotations;

public class Lot
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

    [Required]
    [StringLength(128)]
    required public string LotNumber
    {
        get;
        set;
    }

    [Required]
    public DateOnly ExpirationDate
    {
        get;
        set;
    }

    required public Item Item
    {
        get;
        set;
    }
}