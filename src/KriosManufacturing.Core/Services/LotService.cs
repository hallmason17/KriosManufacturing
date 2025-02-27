namespace KriosManufacturing.Core.Services;

using System;
using System.Threading;
using System.Threading.Tasks;

using Models;
using Repositories;

using Microsoft.Extensions.Logging;

public class LotService(ILogger<LotService> logger, ILotRepository lotRepository)
{
    public async Task<Lot?> CreateAsync(Lot lot, CancellationToken ctok)
    {
        return await lotRepository.CreateAsync(lot, ctok);
    }

    /*
public async Task<IEnumerable<Lot>> GetAllAsync(CancellationToken ctok)
{
   return await dbContext.Lots.ToListAsync(ctok);
}

public async Task<Lot?> GetById(long id, CancellationToken ctok)
{
   return await dbContext.Lots.FindAsync(id, ctok);
}

public async Task CreateAsync(Lot lot, CancellationToken ctok)
{
   dbContext.Lots.Add(lot);
   await dbContext.SaveChangesAsync(ctok);
}

public async Task<bool> DeleteByIdAsync(long id, CancellationToken ctok)
{
   int result = await dbContext.Lots.Where(x => x.Id == id).ExecuteDeleteAsync(ctok);
   return result > 0;
}

public async Task<Lot?> UpdateAsync(Lot lot, CancellationToken ctok)
{
   dbContext.Lots.Update(lot);
   int result = await dbContext.SaveChangesAsync(ctok);
   return result > 0 ? lot : default;
}
*/
    public async Task<Lot?> GetByLotNumberAsync(string lotNumber, CancellationToken ctok)
    {
        return await lotRepository.GetByLotNumberAsync(lotNumber, ctok);
    }
}