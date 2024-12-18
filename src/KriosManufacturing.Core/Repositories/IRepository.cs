namespace KriosManufacturing.Core.Repositories;

public interface IRepository<T>
where T : class
{

    Task<IEnumerable<T>> GetAll(CancellationToken ctok);

    Task<T?> GetById(long id, CancellationToken ctok);

    Task<T?> CreateAsync(T item, CancellationToken ctok);

    Task<T?> UpdateAsync(T item, CancellationToken ctok);

    Task<bool> DeleteByIdAsync(long id, CancellationToken ctok);
}
