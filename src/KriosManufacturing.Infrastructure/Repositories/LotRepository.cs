namespace KriosManufacturing.Infrastructure.Repositories;

using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Repositories;

using KriosManufacturing.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
public class LotRepository(AppDbContext _dbContext) : Repository<Lot>(_dbContext), ILotRepository
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
{
    protected AppDbContext dbContext = _dbContext;
    public async Task<Lot?> GetByLotNumberAsync(string lotNumber, CancellationToken ctok)
    {
        return await dbContext.Lots.Where(l => l.LotNumber == lotNumber).SingleOrDefaultAsync(ctok);
    }
}
