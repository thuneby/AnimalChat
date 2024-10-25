var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AnimalChat_ApiService>("apiservice");

builder.AddProject<Projects.AnimalChat_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
