using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KriosManufacturing.Core.Services;

public class InventoryService(ILogger<InventoryService> logger, AppDbContext dbContext)
{
    public async Task<IEnumerable<InventoryRecord>> GetByItemAsync(long id, CancellationToken ctok)
    {
        return await dbContext.InventoryRecords
            .Where(x => x.Item.Id == id)
            .ToListAsync(ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLocationAsync(long id, CancellationToken ctok)
    {
        return await dbContext.InventoryRecords
            .Where(x => x.Location.Id == id)
            .ToListAsync(ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLotAsync(long id, CancellationToken ctok)
    {
        return await dbContext.InventoryRecords
            .Where(x => x.Lot.Id == id)
            .ToListAsync(ctok);
    }
}