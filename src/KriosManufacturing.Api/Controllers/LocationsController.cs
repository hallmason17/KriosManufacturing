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
        var locations = await _locationService.GetAllAsync(ctok);
        return Ok(locations);
    }

    [HttpGet("{locationId}")]
    public async Task<IActionResult> GetLocation(long locationId, CancellationToken ctok)
    {
        var location = await _locationService.GetByIdAsync(locationId, ctok);
        return location switch
        {
            null => NotFound(),
            _ => Ok(location)
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationRequest locationRequest, CancellationToken ctok)
    {
        var newLocation = await _locationService.CreateAsync(locationRequest.ToLocation(), ctok);
        return newLocation == null ?
            Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Location not created")
            : CreatedAtAction(nameof(GetLocation), new { LocationId = newLocation.Id }, LocationResponse.FromLocation(newLocation));
    }

    [HttpPut("{locationId}")]
    public async Task<IActionResult> UpdateLocation(long locationId, Location location, CancellationToken ctok)
    {
        if (locationId != location.Id)
        {
            return BadRequest();
        }

        await _locationService.UpdateAsync(location, ctok);

        return NoContent();
        /*
        var newLocation = await _locationService.UpdateAsync(location, ctok);
        return newLocation switch
        {
            null => Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Location not updated"),
            _ => Ok(newLocation)
        };
        */
    }

    [HttpDelete("{locationId:long}")]
    public async Task<IActionResult> DeleteLocation(long locationId, CancellationToken ctok)
    {
        var isDeleted = await _locationService.DeleteByIdAsync(locationId, ctok);
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

public record LocationResponse(long Id, string Unit, string Cell)
{
    public static LocationResponse FromLocation(Location location)
    {
        return new LocationResponse(
            location.Id,
            location.Unit,
            location.Cell);
    }
}