namespace KriosManufacturing.Core.Services;

using KriosManufacturing.Core.Repositories;
using KriosManufacturing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ItemService(ILogger<ItemService> logger, IItemRepository itemRepository)
{
    public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken ctok)
    {
        return await itemRepository.GetAll(ctok);
    }

    public async Task<Item?> GetByIdAsync(long id, CancellationToken ctok)
    {
        return await itemRepository.GetById(id, ctok);
    }

    public async Task<Item?> GetBySkuAsync(string sku, CancellationToken ctok)
    {
        return await itemRepository.GetBySkuAsync(sku, ctok); 
    }

    public async Task<Item?> CreateAsync(Item item, CancellationToken ctok)
    {
        return await itemRepository.CreateAsync(item, ctok);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken ctok)
    {
        return await itemRepository.DeleteByIdAsync(id, ctok);
    }

    public async Task<Item?> UpdateAsync(Item item, CancellationToken ctok)
    {
        /*
        var currentItem = await _dbContext.Items.AsNoTracking().FirstAsync(x => x.Id == item.Id, ctok)
                           ?? throw new ArgumentException("Item does not exist.");

        if (item.Sku != currentItem.Sku)
        {
            throw new ArgumentException("Cannot change sku of an item.");
        }

        _dbContext.Items.Update(item);
        int result = await _dbContext.SaveChangesAsync(ctok);
        return result > 0 ? item : default;
        */
        return await itemRepository.UpdateAsync(item, ctok);
    }
}