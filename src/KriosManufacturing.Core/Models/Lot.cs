using System.ComponentModel.DataAnnotations;

namespace KriosManufacturing.Core.Models;

public class Lot
{
    public long Id
    {
        get; set;
    }

    public long ItemId
    {
        get; set;
    }

    [Required]
    [StringLength(100)]
    public required string LotNumber
    {
        get; set;
    }

    [Required]
    public DateOnly ExpirationDate
    {
        get; set;
    }

    public required Item Item
    {
        get; set;
    }
}