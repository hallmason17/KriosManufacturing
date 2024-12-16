using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KriosManufacturing.Core.Services;

public class ItemService(ILogger<ItemService> logger, AppDbContext _dbContext)
{
    public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken ctok)
    {
        return await _dbContext.Items.ToListAsync(ctok);
    }

    public async Task<Item?> GetByIdAsync(long id, CancellationToken ctok)
    {
        return await _dbContext.Items.FindAsync(id, ctok);
    }

    public async Task<Item?> GetBySkuAsync(string sku, CancellationToken ctok)
    {
        return await _dbContext.Items.Where(x => x.Sku == sku)
            .SingleOrDefaultAsync(ctok);
    }

    public async Task<Item?> CreateAsync(Item item, CancellationToken ctok)
    {
        _dbContext.Items.Add(item);
        int result = await _dbContext.SaveChangesAsync(ctok);
        return result > 0 ? item : default;
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken ctok)
    {
        int result = await _dbContext.Items.Where(x => x.Id == id)
            .ExecuteDeleteAsync(ctok);
        return result > 0;
    }

    public async Task<Item?> UpdateAsync(Item item, CancellationToken ctok)
    {
        var currentItem = await _dbContext.Items.AsNoTracking().FirstAsync(x => x.Id == item.Id, ctok)
                           ?? throw new ArgumentException("Item does not exist.");

        if (item.Sku != currentItem.Sku)
        {
            throw new ArgumentException("Cannot change sku of an item.");
        }

        _dbContext.Items.Update(item);
        int result = await _dbContext.SaveChangesAsync(ctok);
        return result > 0 ? item : default;
    }
}