using KriosManufacturing.Core.DbContexts;
using KriosManufacturing.Core.Services;
using KriosManufacturing.ServiceDefaults;

using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
{
    _ = builder.Services
        .AddDbContext<AppDbContext>(opts =>
        {
            _ = opts.UseNpgsql("Server=localhost;Port=5432;Database=KriosManufacturing;Username=postgres;Password=Vince123");
        })
        .AddScoped<ItemService>()
        .AddOpenApi()
        .AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                  policy =>
                  {
                      _ = policy.WithOrigins("http://localhost:5155").AllowAnyMethod().AllowAnyHeader();
                  });
        })
        .AddControllers();

    builder.AddServiceDefaults();
}


var app = builder.Build();
{
    //app.UseExceptionHandler();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors(MyAllowSpecificOrigins);

    app.Run();
}