namespace KriosManufacturing.Infrastructure.Repositories;

using Core.Models;

using Data;

using KriosManufacturing.Core.Repositories;

using Microsoft.EntityFrameworkCore;

public class LotRepository(AppDbContext dbContext) : Repository<Lot>(dbContext), ILotRepository
{
    protected AppDbContext dbContext { get; set; } = dbContext;

    public async Task<Lot?> GetByLotNumberAsync(string lotNumber, CancellationToken ctok)
    {
        return dbContext.Lots is null
            ? null
            : await dbContext.Lots.Where(l => l.LotNumber == lotNumber).SingleOrDefaultAsync(ctok).ConfigureAwait(false);
    }
}