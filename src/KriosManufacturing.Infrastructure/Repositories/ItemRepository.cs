namespace KriosManufacturing.Infrastructure.Repositories;

using System.Threading;
using System.Threading.Tasks;

using Core.Models;

using Data;

using KriosManufacturing.Core.Repositories;

using Microsoft.EntityFrameworkCore;

public class ItemRepository(AppDbContext dbContext) : Repository<Item>(dbContext), IItemRepository
{
    protected AppDbContext dbContext { get; set; } = dbContext;

    public Task<Item?> GetBySkuAsync(string sku, CancellationToken ctok)
    {
        return dbContext.Items is null
            ? Task.FromResult<Item?>(null)
            : dbContext.Items.Where(it => it.Sku == sku).SingleOrDefaultAsync(ctok);
    }
}