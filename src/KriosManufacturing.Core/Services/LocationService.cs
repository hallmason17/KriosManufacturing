using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KriosManufacturing.Core.Services;
public class LocationService(ILogger<LocationService> logger, AppDbContext context)
{
    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await context.Locations.ToListAsync();
    }

    public async Task<Location?> GetById(long id)
    {
        return await context.Locations.FindAsync(id);
    }

    public async Task CreateAsync(Location location)
    {
        context.Locations.Add(location);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var result = await context.Locations.Where(x => x.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }

    public async Task<Location?> UpdateAsync(Location location)
    {
        context.Locations.Update(location);
        var result = await context.SaveChangesAsync();
        return result > 0 ? location : default;
    }
}