namespace KriosManufacturing.Infrastructure.Repositories;

using System.Collections.Generic;

using Core.Models;

using KriosManufacturing.Core.Repositories;

using Data;

using Microsoft.EntityFrameworkCore;

public class InventoryRecordRepository(AppDbContext dbContext) : Repository<InventoryRecord>(dbContext), IInventoryRecordRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public override async Task<IEnumerable<InventoryRecord>> GetAll(CancellationToken ctok)
    {
        return await _dbContext.InventoryRecords
            .AsNoTracking()
            .Include(x => x.Item)
            .Include(x => x.Lot)
            .Include(x => x.Location)
            .ToListAsync(ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByItemAsync(long itemId, CancellationToken ctok)
    {
        return await _dbContext.InventoryRecords.Where(it => it.ItemId == itemId).ToListAsync(ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLocationAsync(long locationId, CancellationToken ctok)
    {
        return await _dbContext.InventoryRecords.Where(it => it.LocationId == locationId).ToListAsync(ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLotAsync(long lotId, CancellationToken ctok)
    {
        return await _dbContext.InventoryRecords.Where(it => it.LotId == lotId).ToListAsync(ctok);
    }
}