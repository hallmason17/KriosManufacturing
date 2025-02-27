namespace KriosManufacturing.Api.Controllers;

using KriosManufacturing.Api.Dtos.Items;
using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Services;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/[controller]")]
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
public class ItemsController(ItemService itemService) : ControllerBase
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
{
    private readonly ItemService _itemService = itemService;
    [HttpGet]
    public async Task<IActionResult> GetItems(CancellationToken ctok)
    {
        var items = await _itemService.GetAllAsync(ctok);
        return Ok(items.OrderBy(x => x.Id));
    }

    [HttpGet("{itemId}")]
    public async Task<IActionResult> GetItem(long itemId, CancellationToken ctok)
    {
        var item = await _itemService.GetByIdAsync(itemId, ctok);
        return item switch
        {
            null => NotFound(),
            _ => Ok(item)
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(CreateItemRequest itemRequest, CancellationToken ctok)
    {
        var newItem = await _itemService.CreateAsync(itemRequest.ToItem(), ctok);
        return newItem == null ?
            Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Item not created")
            : CreatedAtAction(nameof(GetItem), new { ItemId = newItem.Id }, ItemResponse.FromItem(newItem));
    }

    [HttpPut("{itemId}")]
    public async Task<IActionResult> UpdateItem(long itemId, Item item, CancellationToken ctok)
    {
        if (itemId != item.Id)
        {
            return BadRequest();
        }

        await _itemService.UpdateAsync(item, ctok);

        return NoContent();
        /*
        var newItem = await _itemService.UpdateAsync(item, ctok);
        return newItem switch
        {
            null => Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Item not updated"),
            _ => Ok(newItem)
        };
        */
    }

    [HttpDelete("{itemId:long}")]
    public async Task<IActionResult> DeleteItem(long itemId, CancellationToken ctok)
    {
        var isDeleted = await _itemService.DeleteByIdAsync(itemId, ctok);
        return !isDeleted ? NotFound() : NoContent();
    }
}