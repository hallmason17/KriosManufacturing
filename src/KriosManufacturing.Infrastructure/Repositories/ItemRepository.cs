namespace KriosManufacturing.Infrastructure.Repositories;

using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using KriosManufacturing.Infrastructure.Data;

#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
public class ItemRepository(AppDbContext _dbContext) : Repository<Item>(_dbContext), IItemRepository
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
{
    protected AppDbContext dbContext = _dbContext;
    public Task<Item?> GetBySkuAsync(string sku, CancellationToken ctok)
    {
        return dbContext.Items.Where(it => it.Sku == sku).SingleOrDefaultAsync(ctok);
    }
}
