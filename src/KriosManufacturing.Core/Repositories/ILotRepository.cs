namespace KriosManufacturing.Core.Repositories;

using System.Threading;
using System.Threading.Tasks;

using Models;
public interface ILotRepository : IRepository<Lot>
{
    Task<Lot?> GetByLotNumberAsync(string lotNumber, CancellationToken ctok);
}