namespace KriosManufacturing.Core.Services;

using Models;

using Repositories;

public class InventoryRecordService(IInventoryRecordRepository inventoryRecordRepository)
{
    public async Task<IEnumerable<InventoryRecord>> GetAllAsync(CancellationToken ctok)
    {
        return await inventoryRecordRepository.GetAll(ctok);
    }

    public async Task<InventoryRecord?> GetByIdAsync(long id, CancellationToken ctok)
    {
        return await inventoryRecordRepository.GetById(id, ctok);
    }

    public async Task<InventoryRecord?> CreateAsync(InventoryRecord inventoryRecord, CancellationToken ctok)
    {
        return await inventoryRecordRepository.CreateAsync(inventoryRecord, ctok);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken ctok)
    {
        return await inventoryRecordRepository.DeleteByIdAsync(id, ctok);
    }

    public async Task<InventoryRecord?> UpdateAsync(InventoryRecord inventoryRecord, CancellationToken ctok)
    {
        /*
        var currentInventoryRecord = await _dbContext.InventoryRecords.AsNoTracking().FirstAsync(x => x.Id == inventoryRecord.Id, ctok)
                           ?? throw new ArgumentException("InventoryRecord does not exist.");

        if (inventoryRecord.Sku != currentInventoryRecord.Sku)
        {
            throw new ArgumentException("Cannot change sku of an inventoryRecord.");
        }

        _dbContext.InventoryRecords.Update(inventoryRecord);
        int result = await _dbContext.SaveChangesAsync(ctok);
        return result > 0 ? inventoryRecord : default;
        */
        return await inventoryRecordRepository.UpdateAsync(inventoryRecord, ctok);
    }

    public async Task<IEnumerable<InventoryRecord>> GetByItemAsync(long itemId, CancellationToken ctok)
    {
        return await inventoryRecordRepository.GetByItemAsync(itemId, ctok).ConfigureAwait(false);
        /*
        return await dbContext.InventoryRecords
            .Where(x => x.Item.Id == id)
            .ToListAsync(ctok);
            */
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLocationAsync(long locationId, CancellationToken ctok)
    {
        return await inventoryRecordRepository.GetByLocationAsync(locationId, ctok).ConfigureAwait(false);
        /*
        return await dbContext.InventoryRecords
            .Where(x => x.Location.Id == id)
            .ToListAsync(ctok);
            */
    }

    public async Task<IEnumerable<InventoryRecord>> GetByLotAsync(long lotId, CancellationToken ctok)
    {
        return await inventoryRecordRepository.GetByLotAsync(lotId, ctok).ConfigureAwait(false);
        /*
        return await dbContext.InventoryRecords
            .Where(x => x.Lot.Id == id)
            .ToListAsync(ctok);
            */
    }
}