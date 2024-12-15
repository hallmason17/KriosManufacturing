namespace KriosManufacturing.Core.Services;
using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ItemService(ILogger<ItemService> logger, AppDbContext context)
{
    public async Task<IEnumerable<Item>> GetAllAsync()
    {
        return await context.Items.ToListAsync();
    }

    public async Task<Item?> GetById(long id)
    {
        return await context.Items.FindAsync(id);
    }

    public async Task CreateAsync(Item item)
    {
        context.Items.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var result = await context.Items.Where(x => x.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }

    public async Task<Item?> UpdateAsync(Item item)
    {
        context.Items.Update(item);
        var result = await context.SaveChangesAsync();
        return result > 0 ? item : default;
    }
}