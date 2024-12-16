namespace KriosManufacturing.Core.Models;

using System.ComponentModel.DataAnnotations;
public class Order
{
    public long Id
    {
        get;
        set;
    }

    [Required]
    [StringLength(32)]
    required public string OrderNumber
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