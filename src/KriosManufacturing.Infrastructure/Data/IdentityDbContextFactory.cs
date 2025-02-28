namespace KriosManufacturing.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
{
    public IdentityContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<IdentityContext> optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Username=postgres;Password=Vince123;Database=KriosManufacturing;Include Error Detail=true");

        return new IdentityContext(optionsBuilder.Options);
    }
}