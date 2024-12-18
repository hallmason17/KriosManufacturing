namespace KriosManufacturing.Infrastructure.Repositories;

using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using KriosManufacturing.Infrastructure.Data;

public class ItemRepository(AppDbContext _dbContext) : Repository<Item>(_dbContext), IItemRepository
{
    protected AppDbContext dbContext = _dbContext;
    public Task<Item?> GetBySkuAsync(string sku, CancellationToken ctok)
    {
        return dbContext.Items.Where(it => it.Sku == sku).FirstOrDefaultAsync(ctok);
    }
}
