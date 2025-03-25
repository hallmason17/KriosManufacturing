namespace KriosManufacturing.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new();
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Username=postgres;Password=Vince123;Database=KriosManufacturing;Include Error Detail=true");

        return new AppDbContext(optionsBuilder.Options);
    }
}