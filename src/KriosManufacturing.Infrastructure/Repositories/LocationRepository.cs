namespace KriosManufacturing.Infrastructure.Repositories;
using Core.Models;
using KriosManufacturing.Core.Repositories;
using Data;

#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
public class LocationRepository(AppDbContext _dbContext) : Repository<Location>(_dbContext), ILocationRepository
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
{
}
