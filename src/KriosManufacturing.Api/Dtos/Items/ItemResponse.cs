namespace KriosManufacturing.Api.Dtos.Items;

using Core.Models;

internal sealed record ItemResponse(long Id, string Sku, string Name, string? Description)
{
    public static ItemResponse FromItem(Item item)
    {
        return new ItemResponse(
            item.Id,
            item.Sku,
            item.Name,
            item.Description);
    }
}