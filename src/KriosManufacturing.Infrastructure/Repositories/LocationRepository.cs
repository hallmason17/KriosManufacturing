namespace KriosManufacturing.Infrastructure.Repositories;
using KriosManufacturing.Core.Models;
using KriosManufacturing.Core.Repositories;
using KriosManufacturing.Infrastructure.Data;

#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
public class LocationRepository(AppDbContext _dbContext) : Repository<Location>(_dbContext), ILocationRepository
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
{
}
