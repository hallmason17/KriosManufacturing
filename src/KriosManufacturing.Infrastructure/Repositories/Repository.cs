namespace KriosManufacturing.Infrastructure.Repositories;

using KriosManufacturing.Core.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using KriosManufacturing.Infrastructure.Data;

public class Repository<T>(AppDbContext dbContext) : IRepository<T>
where T : class
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task<T?> CreateAsync(T item, CancellationToken ctok)
    {
        await dbContext.AddAsync(item, ctok).ConfigureAwait(false);
        var result = await dbContext.SaveChangesAsync(ctok).ConfigureAwait(false);
        return result > 0 ? item : default;
    }

    public async Task<bool> DeleteByIdAsync(long itemId, CancellationToken ctok)
    {
        var item = await dbContext.FindAsync<T>(itemId);
        if (item == null)
        {
            return false;
        }

        if (dbContext.Entry(item).State == EntityState.Detached)
        {
            _dbSet.Attach(item);
        }

        _dbSet.Remove(item);
        var result = await dbContext.SaveChangesAsync(ctok);
        return result > 0;
    }

    public async Task<IEnumerable<T>> GetAll(CancellationToken ctok)
    {
        return await _dbSet.ToListAsync(ctok).ConfigureAwait(false);
    }

    public async Task<T?> GetById(long itemId, CancellationToken ctok)
    {
        return await _dbSet.FindAsync(itemId, ctok).ConfigureAwait(false);
    }

    public async Task<T?> UpdateAsync(T item, CancellationToken ctok)
    {
        _dbSet.Update(item);
        var result = await dbContext.SaveChangesAsync(ctok).ConfigureAwait(false);
        return result > 0 ? item : default;
    }
}
