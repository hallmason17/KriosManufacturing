namespace KriosManufacturing.Api.Controllers;

using KriosManufacturing.Api.Dtos.Items;
using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Services;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/[controller]")]
public class InventoryRecordsController(InventoryRecordService inventoryRecordService) : ControllerBase
{
    private readonly InventoryRecordService _inventoryRecordService = inventoryRecordService;
    [HttpGet]
    public async Task<IActionResult> GetInventoryRecords(CancellationToken ctok)
    {
        var inventoryRecords = await _inventoryRecordService.GetAllAsync(ctok);
        return Ok(inventoryRecords);
    }

    [HttpGet("{inventoryRecordId}")]
    public async Task<IActionResult> GetInventoryRecord(long inventoryRecordId, CancellationToken ctok)
    {
        var inventoryRecord = await _inventoryRecordService.GetByIdAsync(inventoryRecordId, ctok);
        return inventoryRecord switch
        {
            null => NotFound(),
            _ => Ok(inventoryRecord)
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateInventoryRecord(CreateInventoryRecordRequest inventoryRecordRequest, CancellationToken ctok)
    {
        var newRecord = await _inventoryRecordService.CreateAsync(inventoryRecordRequest.ToInventoryRecord(), ctok);
        return newRecord == null ?
            Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Inventory record not created")
            : CreatedAtAction(nameof(GetInventoryRecord), new { InventoryRecordId = newRecord.Id }, InventoryRecordResponse.FromInventoryRecord(newRecord));
    }

    [HttpPut("{itemId}")]
    public async Task<IActionResult> UpdateInventoryRecord(long inventoryRecordId, InventoryRecord inventoryRecord, CancellationToken ctok)
    {
        if (inventoryRecordId != inventoryRecord.Id)
        {
            return BadRequest();
        }

        await _inventoryRecordService.UpdateAsync(inventoryRecord, ctok);

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

    [HttpDelete("{inventoryRecordId:long}")]
    public async Task<IActionResult> DeleteItem(long inventoryRecordId, CancellationToken ctok)
    {
        var isDeleted = await _inventoryRecordService.DeleteByIdAsync(inventoryRecordId, ctok);
        return !isDeleted ? NotFound() : NoContent();
    }
}

public record CreateInventoryRecordRequest(long Id, long ItemId, long LocationId, long LotId, int Quantity)
{
    public InventoryRecord ToInventoryRecord()
    {
        return new InventoryRecord()
        {
            Id = Id,
            ItemId = ItemId,
            LocationId = LocationId,
            LotId = LotId,
            Quantity = Quantity,
        };
    }
}

public record InventoryRecordResponse(long Id, long ItemId, long LocationId, long LotId, int Quantity)
{
    public static InventoryRecordResponse FromInventoryRecord(InventoryRecord inventoryRecord)
    {
        return new InventoryRecordResponse(
            inventoryRecord.Id,
            inventoryRecord.ItemId,
            inventoryRecord.LocationId,
            inventoryRecord.LotId,
            inventoryRecord.Quantity);
    }
}