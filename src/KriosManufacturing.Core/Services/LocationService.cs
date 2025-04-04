namespace KriosManufacturing.Core.Services;

using Microsoft.Extensions.Logging;

using Models;

using Repositories;

public class LocationService(ILogger<LocationService> logger, ILocationRepository locationRepository)
{
    public async Task<IEnumerable<Location>> GetAllAsync(CancellationToken ctok)
    {
        return await locationRepository.GetAll(ctok).ConfigureAwait(false);
    }

    public async Task<Location?> GetByIdAsync(long id, CancellationToken ctok)
    {
        return await locationRepository.GetById(id, ctok).ConfigureAwait(false);
    }

    public async Task<Location?> CreateAsync(Location location, CancellationToken ctok)
    {
        return await locationRepository.CreateAsync(location, ctok).ConfigureAwait(false);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken ctok)
    {
        return await locationRepository.DeleteByIdAsync(id, ctok).ConfigureAwait(false);
    }

    public async Task<Location?> UpdateAsync(Location location, CancellationToken ctok)
    {
        /*
        var currentLocation = await _dbContext.Locations.AsNoTracking().FirstAsync(x => x.Id == location.Id, ctok)
                           ?? throw new ArgumentException("Location does not exist.");

        if (location.Sku != currentLocation.Sku)
        {
            throw new ArgumentException("Cannot change sku of an location.");
        }

        _dbContext.Locations.Update(location);
        int result = await _dbContext.SaveChangesAsync(ctok);
        return result > 0 ? location : default;
        */
        return await locationRepository.UpdateAsync(location, ctok).ConfigureAwait(false);
    }
}