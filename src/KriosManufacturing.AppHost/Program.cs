var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.KriosManufacturing_Api>("Api")
    .WithExternalHttpEndpoints();

var frontend = builder.AddProject<Projects.KriosManufacturing_WebApplication>("FrontEnd")
        .WithExternalHttpEndpoints()
        .WithReference(api);

builder.Build().Run();
