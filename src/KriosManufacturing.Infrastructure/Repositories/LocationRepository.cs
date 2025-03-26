namespace KriosManufacturing.Infrastructure.Repositories;
using Core.Models;

using Data;

using KriosManufacturing.Core.Repositories;

public class LocationRepository(AppDbContext dbContext) : Repository<Location>(dbContext), ILocationRepository
{
}