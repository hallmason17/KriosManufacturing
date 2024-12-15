using KriosManufacturing.Api.Dtos.Items;
using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Services;

using Microsoft.AspNetCore.Mvc;

namespace KriosManufacturing.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ItemsController(ItemService itemService) : ControllerBase
{
    [HttpOptions("{id}")]
    public IActionResult PreflightRoute(int id)
    {
        return NoContent();
    }

    [HttpOptions]
    public IActionResult PreflightRoute()
    {
        return NoContent();
    }

    private readonly ItemService _itemService = itemService;
    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _itemService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{itemId}")]
    public async Task<IActionResult> GetItem(long itemId)
    {
        var item = await _itemService.GetByIdAsync(itemId);
        return item switch
        {
            null => NotFound(),
            _ => Ok(item)
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(CreateItemRequest itemRequest)
    {
        var newItem = await _itemService.CreateAsync(itemRequest.ToItem());
        return newItem == null ?
            Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Item not created")
            : CreatedAtAction(nameof(GetItem), new { ItemId = newItem.Id }, ItemResponse.FromItem(newItem));
    }

    [HttpPut("{itemId}")]
    public async Task<IActionResult> UpdateItem(long itemId, Item item)
    {
        var newItem = await _itemService.UpdateAsync(item);
        return newItem switch
        {
            null => Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Item not updated"),
            _ => Ok(newItem)
        };
    }

    [HttpDelete("{itemId}")]
    public async Task<IActionResult> DeleteItem(long itemId)
    {
        var isDeleted = await _itemService.DeleteByIdAsync(itemId);
        return !isDeleted ? NotFound() : NoContent();
    }

}