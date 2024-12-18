namespace KriosManufacturing.Core.Repositories;

using KriosManufacturing.Core.Models;
public interface IItemRepository : IRepository<Item>
{
    Task<Item?> GetBySkuAsync(string sku, CancellationToken ctok);
}
