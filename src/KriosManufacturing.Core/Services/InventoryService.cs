namespace KriosManufacturing.Core.Services;

using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class InventoryService(ILogger<InventoryService> logger, AppDbContext dbContext)
{
    public async Task<IEnumerable<InventoryRecord>> GetByItemAsync(long id)
    {
        return await dbContext.InventoryRecords
        .Where(x => x.Item.Id == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLocationAsync(long id)
    {
        return await dbContext.InventoryRecords
        .Where(x => x.Location.Id == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLotAsync(long id)
    {
        return await dbContext.InventoryRecords
        .Where(x => x.Lot.Id == id)
        .ToListAsync();
    }
}