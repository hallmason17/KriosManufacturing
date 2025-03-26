namespace KriosManufacturing.Core.Repositories;

using Models;
public interface IItemRepository : IRepository<Item>
{
    Task<Item?> GetBySkuAsync(string sku, CancellationToken ctok);
}