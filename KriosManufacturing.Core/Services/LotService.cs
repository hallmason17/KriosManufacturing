namespace KriosManufacturing.Core.Services;

using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class LotService(ILogger<LotService> logger, AppDbContext dbContext)
{
    public async Task<IEnumerable<Lot>> GetAllAsync()
    {
        return await dbContext.Lots.ToListAsync();
    }

    public async Task<Lot?> GetById(long id)
    {
        return await dbContext.Lots.FindAsync(id);
    }

    public async Task CreateAsync(Lot lot)
    {
        dbContext.Lots.Add(lot);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var result = await dbContext.Lots.Where(x => x.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }

    public async Task<Lot?> UpdateAsync(Lot lot)
    {
        dbContext.Lots.Update(lot);
        var result = await dbContext.SaveChangesAsync();
        return result > 0 ? lot : default;
    }
}