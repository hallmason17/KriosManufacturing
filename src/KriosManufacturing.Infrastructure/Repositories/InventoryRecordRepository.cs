namespace KriosManufacturing.Infrastructure.Repositories;

using System.Collections.Generic;


using KriosManufacturing.Core.Models;

using KriosManufacturing.Core.Repositories;

using KriosManufacturing.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;


public class InventoryRecordRepository(AppDbContext _dbContext) : Repository<InventoryRecord>(_dbContext), IInventoryRecordRepository 
{
    protected AppDbContext dbContext = _dbContext;

    public override async Task<IEnumerable<InventoryRecord>> GetAll(CancellationToken ctok)
    {
        return await dbContext.InventoryRecords
            .AsNoTracking()
            .Include(x => x.Item)
            .Include(x => x.Lot)
            .Include(x => x.Location)
            .ToListAsync(ctok);
    }

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