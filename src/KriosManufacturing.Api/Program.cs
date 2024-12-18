using System.Text.Json.Serialization;

using KriosManufacturing.Core.Repositories;
using KriosManufacturing.Core.Services;
using KriosManufacturing.Infrastructure.Data;
using KriosManufacturing.Infrastructure.Repositories;
using KriosManufacturing.ServiceDefaults;

using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
{
    _ = builder.Services
        .AddDbContext<AppDbContext>(opts =>
        {
            _ = opts.UseNpgsql("Server=localhost;Port=5432;Database=KriosManufacturing;Username=postgres;Password=Vince123");
        })
        .AddScoped<IItemRepository, ItemRepository>()
        .AddScoped<IInventoryRecordRepository, InventoryRecordRepository>()
        .AddScoped<InventoryRecordService>()
        .AddScoped<ItemService>()
        .AddOpenApi()
        .AddCors(options =>
        {
            options.AddPolicy(
                name: myAllowSpecificOrigins,
                policy =>
                {
                    _ = policy.WithOrigins("http://localhost").AllowAnyMethod().AllowAnyHeader();
                });
        })
        .AddControllers()
        .AddJsonOptions(opts => {
            opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opts.JsonSerializerOptions.WriteIndented = true;
        });

    builder.AddServiceDefaults();
}

var app = builder.Build();
{
    // app.UseExceptionHandler();
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference(opts =>
        {
            opts.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors(myAllowSpecificOrigins);

    app.Run();
}