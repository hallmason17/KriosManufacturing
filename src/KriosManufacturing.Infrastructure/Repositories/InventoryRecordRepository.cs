namespace KriosManufacturing.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

using Core.Models;

using Data;

using KriosManufacturing.Core.Repositories;

using Microsoft.EntityFrameworkCore;

public class InventoryRecordRepository(AppDbContext dbContext) : Repository<InventoryRecord>(dbContext), IInventoryRecordRepository
{
    protected AppDbContext dbContext { get; set; } = dbContext;

    public override async Task<IEnumerable<InventoryRecord>> GetAll(CancellationToken ctok)
    {
        return dbContext.InventoryRecords is null ?
        [] :
        await dbContext.InventoryRecords
            .AsNoTracking()
            .Include(x => x.Item)
            .Include(x => x.Lot)
            .Include(x => x.Location)
            .ToListAsync(ctok).ConfigureAwait(false);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByItemAsync(long itemId, CancellationToken ctok)
    {
        return dbContext.InventoryRecords is null ?
        [] :
                await dbContext.InventoryRecords.Where(it => it.ItemId == itemId).ToListAsync(ctok).ConfigureAwait(false);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLocationAsync(long locationId, CancellationToken ctok)
    {
        return dbContext.InventoryRecords is null ?
        [] :
                await dbContext.InventoryRecords.Where(it => it.LocationId == locationId).ToListAsync(ctok).ConfigureAwait(false);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLotAsync(long lotId, CancellationToken ctok)
    {
        return dbContext.InventoryRecords is null ?
        [] :
        await dbContext.InventoryRecords.Where(it => it.LotId == lotId).ToListAsync(ctok).ConfigureAwait(false);
    }
}