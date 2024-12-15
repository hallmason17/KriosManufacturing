using KriosManufacturing.Core.Models;

namespace KriosManufacturing.Api.Dtos.Items;

public record CreateItemRequest(string Sku, string Name, string? Description)
{

    public Item ToItem()
    {
        return new Item()
        {
            Sku = Sku,
            Name = Name,
            Description = Description,
        };
    }
}