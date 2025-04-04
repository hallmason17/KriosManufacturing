namespace KriosManufacturing.Api.Controllers;

using System.Diagnostics;

using Core.Models;
using Core.Services;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/[controller]")]
public class InventoryRecordsController(
        ILogger<InventoryRecordsController> logger,
        InventoryRecordService inventoryRecordService,
        ItemService itemService,
        LocationService locationService,
        LotService lotService) : ControllerBase
{
    private readonly InventoryRecordService _inventoryRecordService = inventoryRecordService;
    private readonly ItemService _itemService = itemService;
    private readonly LocationService _locationService = locationService;

    private readonly LotService _lotService = lotService;
    [HttpGet]
    public async Task<IActionResult> GetInventoryRecords(CancellationToken ctok)
    {
        var inventoryRecords = await _inventoryRecordService.GetAllAsync(ctok).ConfigureAwait(false);
        return Ok(inventoryRecords);
    }

    [HttpGet("{inventoryRecordId}")]
    public async Task<IActionResult> GetInventoryRecord(
            long inventoryRecordId,
            CancellationToken ctok)
    {
        var inventoryRecord = await _inventoryRecordService.GetByIdAsync(inventoryRecordId, ctok).ConfigureAwait(false);
        return inventoryRecord switch
        {
            null => NotFound(),
            _ => Ok(inventoryRecord)
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateInventoryRecord(
            CreateInventoryRecordRequest inventoryRecordRequest,
            CancellationToken ctok)
    {
        if (inventoryRecordRequest is null)
        {
            return BadRequest();
        }

        var sw = new Stopwatch();
        sw.Start();

        if (inventoryRecordRequest.Quantity < 1)
        {
            return BadRequest("Quantity must be greater than 0.");
        }

        var item = await _itemService.GetBySkuAsync(inventoryRecordRequest.Sku, ctok).ConfigureAwait(false);
        if (item is null)
        {
            return NotFound("Item not found.");
        }

        // TODO: Get default receive location
        var location = await _locationService.GetByIdAsync(5, ctok).ConfigureAwait(false);
        if (location is null)
        {
            return NotFound("Location not found.");
        }

        var lot = await _lotService.GetByLotNumberAsync(inventoryRecordRequest.LotNumber, ctok).ConfigureAwait(false);
        lot ??= new Lot()
        {
            ItemId = item.Id,
            LotNumber = inventoryRecordRequest.LotNumber,
            ExpirationDate = DateOnly.FromDateTime(inventoryRecordRequest.LotExpirationDate),
        };

        var inventoryRecord = new InventoryRecord()
        {
            Id = inventoryRecordRequest.Id,
            ItemId = item.Id,
            LocationId = location.Id,
            LotId = lot.Id,
            Quantity = inventoryRecordRequest.Quantity,
        };

        var newRecord = await _inventoryRecordService.CreateAsync(inventoryRecord, ctok).ConfigureAwait(false);
        logger.LogInformation("CreateInventoryRecords took {ElapsedMilliseconds}ms", sw.ElapsedMilliseconds);
        return newRecord == null ?
            Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: $"Inventory record not created")
            : CreatedAtAction(
                nameof(GetInventoryRecord),
                new { InventoryRecordId = newRecord.Id },
                InventoryRecordResponse.FromInventoryRecord(newRecord));
    }

    [HttpPut("{inventoryRecordId}")]
    public async Task<IActionResult> UpdateInventoryRecord(
            long inventoryRecordId,
            InventoryRecord inventoryRecord,
            CancellationToken ctok)
    {
        if (inventoryRecord is null)
        {
            return BadRequest();
        }

        if (inventoryRecordId != inventoryRecord.Id)
        {
            return BadRequest();
        }

        await _inventoryRecordService.UpdateAsync(inventoryRecord, ctok).ConfigureAwait(false);

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
        var isDeleted = await _inventoryRecordService.DeleteByIdAsync(inventoryRecordId, ctok).ConfigureAwait(false);
        return !isDeleted ? NotFound() : NoContent();
    }
}

public record CreateInventoryRecordRequest(
        long Id,
        string Sku,
        string LotNumber,
        DateTime LotExpirationDate,
        int Quantity)
{
}

internal sealed record InventoryRecordResponse(
        long Id,
        long ItemId,
        long LocationId,
        long LotId,
        int Quantity)
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