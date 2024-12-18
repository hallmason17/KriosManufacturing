namespace KriosManufacturing.Infrastructure.Repositories;
using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Repositories;
using KriosManufacturing.Infrastructure.Data;

public class LocationRepository(AppDbContext _dbContext) : Repository<Location>(_dbContext), ILocationRepository
{
}
