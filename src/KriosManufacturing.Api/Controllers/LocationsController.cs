namespace KriosManufacturing.Api.Controllers;

using Core.Models;
using Core.Services;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/[controller]")]
public class LocationsController(LocationService locationService) : ControllerBase
{
    private readonly LocationService _locationService = locationService;
    [HttpGet]
    public async Task<IActionResult> GetLocations(CancellationToken ctok)
    {
        var locations = await _locationService.GetAllAsync(ctok).ConfigureAwait(false);
        return Ok(locations);
    }

    [HttpGet("{locationId}")]
    public async Task<IActionResult> GetLocation(long locationId, CancellationToken ctok)
    {
        var location = await _locationService.GetByIdAsync(locationId, ctok).ConfigureAwait(false);
        return location switch
        {
            null => NotFound(),
            _ => Ok(location)
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationRequest locationRequest, CancellationToken ctok)
    {
        if (locationRequest == null) return BadRequest();
        var newLocation = await _locationService.CreateAsync(locationRequest.ToLocation(), ctok).ConfigureAwait(false);
        return newLocation == null ?
            Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Location not created")
            : CreatedAtAction(nameof(GetLocation), new { LocationId = newLocation.Id }, LocationResponse.FromLocation(newLocation));
    }

    [HttpPut("{locationId}")]
    public async Task<IActionResult> UpdateLocation(long locationId, Location location, CancellationToken ctok)
    {
        if (location is null || locationId != location.Id)
        {
            return BadRequest();
        }

        var newLocation = await _locationService.UpdateAsync(location, ctok).ConfigureAwait(false);
        return newLocation switch
        {
            null => Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Location not updated"),
            _ => NoContent()
        };
    }

    [HttpDelete("{locationId:long}")]
    public async Task<IActionResult> DeleteLocation(long locationId, CancellationToken ctok)
    {
        var isDeleted = await _locationService.DeleteByIdAsync(locationId, ctok).ConfigureAwait(false);
        return !isDeleted ? NotFound() : NoContent();
    }
}

public record CreateLocationRequest(long Id, string Unit, string Cell)
{
    public Location ToLocation()
    {
        return new Location()
        {
            Id = Id,
            Unit = Unit,
            Cell = Cell,
        };
    }
}

internal sealed record LocationResponse(long Id, string Unit, string Cell)
{
    public static LocationResponse FromLocation(Location location)
    {
        return new LocationResponse(
            location.Id,
            location.Unit,
            location.Cell);
    }
}