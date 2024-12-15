using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KriosManufacturing.Core.Services;
public class ItemService(ILogger<ItemService> logger, AppDbContext _dbContext)
{
    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await _dbContext.Items.ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(long id)
    {
        return await _dbContext.Items.FindAsync(id);
    }

    public async Task<Item?> GetBySkuAsync(string sku)
    {
        return await _dbContext.Items.Where(x => x.Sku == sku).SingleOrDefaultAsync();
    }

    public async Task<Item?> CreateAsync(Item item)
    {
        _dbContext.Items.Add(item);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? item : default;
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var result = await _dbContext.Items.Where(x => x.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }

    public async Task<Item?> UpdateAsync(Item item)
    {
        var currentItem = await _dbContext.Items.AsNoTracking().FirstAsync(x => x.Id == item.Id)
            ?? throw new ArgumentException("Item does not exist.");

        if (item.Sku != currentItem.Sku)
        {
            throw new ArgumentException("Cannot change sku of an item.");
        }

        _dbContext.Items.Update(item);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? item : default;
    }
}