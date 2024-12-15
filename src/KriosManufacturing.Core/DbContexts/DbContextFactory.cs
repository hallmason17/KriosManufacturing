using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KriosManufacturing.Core.DbContexts;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=Vince123;Database=KriosManufacturing;Include Error Detail=true");

        return new AppDbContext(optionsBuilder.Options);
    }
}