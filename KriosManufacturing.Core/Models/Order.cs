namespace KriosManufacturing.Core.Models
{
    public class Order
    {
        public long Id { get; set; }
        public required string OrderNumber { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}