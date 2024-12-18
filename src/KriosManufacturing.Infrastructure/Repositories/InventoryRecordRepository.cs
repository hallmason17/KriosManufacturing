namespace KriosManufacturing.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Data.Entity;


using KriosManufacturing.Core.Models;

using KriosManufacturing.Core.Repositories;

using KriosManufacturing.Infrastructure.Data;
public class InventoryRecordRepository(AppDbContext _dbContext) : Repository<InventoryRecord>(_dbContext), IInventoryRecordRepository 
{
    protected AppDbContext dbContext = _dbContext;

    public async Task<IEnumerable<InventoryRecord>> GetByItemAsync(long itemId, CancellationToken ctok)
    {
        return await dbContext.InventoryRecords.Where(it => it.ItemId == itemId).ToListAsync(ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLocationAsync(long locationId, CancellationToken ctok)
    {
        return await dbContext.InventoryRecords.Where(it => it.ItemId == locationId).ToListAsync(ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLotAsync(long lotId, CancellationToken ctok)
    {
        return await dbContext.InventoryRecords.Where(it => it.ItemId == lotId).ToListAsync(ctok);
    }
}