namespace KriosManufacturing.Core.Services;

using Microsoft.Extensions.Logging;

public class LocationService(ILogger<LocationService> logger)
{
    /*
    public async Task<IEnumerable<Location>> GetAllAsync(CancellationToken ctok)
    {
        return await context.Locations.ToListAsync(ctok);
    }

    public async Task<Location?> GetById(long id, CancellationToken ctok)
    {
        return await context.Locations.FindAsync(id, ctok);
    }

    public async Task CreateAsync(Location location, CancellationToken ctok)
    {
        context.Locations.Add(location);
        await context.SaveChangesAsync(ctok);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken ctok)
    {
        int result = await context.Locations.Where(x => x.Id == id)
            .ExecuteDeleteAsync(ctok);
        return result > 0;
    }

    public async Task<Location?> UpdateAsync(Location location, CancellationToken ctok)
    {
        context.Locations.Update(location);
        int result = await context.SaveChangesAsync(ctok);
        return result > 0 ? location : default;
    }
    */
}