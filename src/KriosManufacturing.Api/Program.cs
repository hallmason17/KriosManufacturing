#pragma warning disable SA1200 // Using directives should be placed correctly
using System.Text.Json.Serialization;

using KriosManufacturing.Core.Repositories;
using KriosManufacturing.Core.Services;
using KriosManufacturing.Infrastructure.Data;
using KriosManufacturing.Infrastructure.Repositories;
using KriosManufacturing.ServiceDefaults;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;
#pragma warning restore SA1200 // Using directives should be placed correctly

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
{
    _ = builder.Services
        .AddDbContext<AppDbContext>(opts =>
        {
            _ = opts.UseNpgsql("Server=localhost;Port=5432;Database=KriosManufacturing;Username=postgres;Password=Vince123");
        })
        .AddDbContext<IdentityContext>(opts =>
        {
            _ = opts.UseNpgsql("Server=localhost;Port=5432;Database=KriosManufacturing;Username=postgres;Password=Vince123");
        })
        .AddScoped<IItemRepository, ItemRepository>()
        .AddScoped<IInventoryRecordRepository, InventoryRecordRepository>()
        .AddScoped<ILocationRepository, LocationRepository>()
        .AddScoped<ILotRepository, LotRepository>()
        .AddScoped<LotService>()
        .AddScoped<LocationService>()
        .AddScoped<InventoryRecordService>()
        .AddScoped<ItemService>()
        .AddOpenApi()
        .AddCors(options =>
        {
            options.AddPolicy(
                name: myAllowSpecificOrigins,
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
        })
        .AddControllers()
        .AddJsonOptions(opts =>
        {
            opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opts.JsonSerializerOptions.WriteIndented = true;
        });

    builder.Services
    .AddAuthentication(opt =>
    {
        opt.DefaultScheme = IdentityConstants.BearerScheme;
    })
    .AddBearerToken(IdentityConstants.BearerScheme, opts =>
    {
        opts.BearerTokenExpiration = TimeSpan.FromMinutes(5);
    });

    var authPolicy = new AuthorizationPolicyBuilder(
        IdentityConstants.BearerScheme)
    .RequireAuthenticatedUser()
    .Build();

    builder.Services.AddAuthorizationBuilder()
    .SetDefaultPolicy(authPolicy);

    builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddApiEndpoints();

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
        });
    }

    app.MapIdentityApi<IdentityUser>();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.UseCors(myAllowSpecificOrigins);

    app.Run();
}