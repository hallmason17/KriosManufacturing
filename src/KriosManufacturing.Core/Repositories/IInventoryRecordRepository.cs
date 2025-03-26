namespace KriosManufacturing.Core.Repositories;

using Models;

public interface IInventoryRecordRepository : IRepository<InventoryRecord>
{
    Task<IEnumerable<InventoryRecord>> GetByItemAsync(long itemId, CancellationToken ctok);
    Task<IEnumerable<InventoryRecord>> GetByLocationAsync(long locationId, CancellationToken ctok);
    Task<IEnumerable<InventoryRecord>> GetByLotAsync(long lotId, CancellationToken ctok);
}