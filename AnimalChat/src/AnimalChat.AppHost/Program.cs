var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AnimalChat_ApiService>("apiservice");

var openai = builder.ExecutionContext.IsPublishMode
    ? builder.AddAzureOpenAI("openAiConnectionName")
    : builder.AddConnectionString("openAiConnectionName");


builder.AddProject<Projects.AnimalChat_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(openai);

builder.Build().Run();
