namespace KriosManufacturing.Infrastructure.Repositories;

using System.Threading;
using System.Threading.Tasks;

using Data;

using KriosManufacturing.Core.Repositories;

using Microsoft.EntityFrameworkCore;

public class Repository<T>(AppDbContext dbContext) : IRepository<T>
where T : class
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public virtual async Task<T?> CreateAsync(T item, CancellationToken ctok)
    {
        await _dbSet.AddAsync(item, ctok).ConfigureAwait(false);
        var result = await dbContext.SaveChangesAsync(ctok).ConfigureAwait(false);
        return result > 0 ? item : default;
    }

    public virtual async Task<bool> DeleteByIdAsync(long id, CancellationToken ctok)
    {
        var item = await dbContext.FindAsync<T>(id).ConfigureAwait(false);
        if (item == null)
        {
            return false;
        }

        if (dbContext.Entry(item).State == EntityState.Detached)
        {
            _dbSet.Attach(item);
        }

        _dbSet.Remove(item);
        var result = await dbContext.SaveChangesAsync(ctok).ConfigureAwait(false);
        return result > 0;
    }

    public virtual async Task<IEnumerable<T>> GetAll(CancellationToken ctok)
    {
        return await _dbSet.ToListAsync(ctok).ConfigureAwait(false);
    }

    public virtual async Task<T?> GetById(long id, CancellationToken ctok)
    {
        return await _dbSet.FindAsync([id], cancellationToken: ctok).ConfigureAwait(false);
    }

    public virtual async Task<T?> UpdateAsync(T item, CancellationToken ctok)
    {
        _dbSet.Update(item);
        var result = await dbContext.SaveChangesAsync(ctok).ConfigureAwait(false);
        return result > 0 ? item : default;
    }
}