using System.ComponentModel.DataAnnotations;

namespace KriosManufacturing.Core.Models;

public class Order
{
    public long Id
    {
        get;
        set;
    }

    [Required]
    [StringLength(30)]
    public required string OrderNumber
    {
        get;
        set;
    }

    public ICollection<OrderDetail>? OrderDetails
    {
        get;
        set;
    }
}