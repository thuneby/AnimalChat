var builder = DistributedApplication.CreateBuilder(args);

var openai = builder.ExecutionContext.IsPublishMode
    ? builder.AddAzureOpenAI("openAiConnectionName")
    : builder.AddConnectionString("openAiConnectionName");

var apiService = 
    builder.AddProject<Projects.AnimalChat_ApiService>("apiservice")
        .WithReference(openai);

builder.AddProject<Projects.AnimalChat_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(openai);

builder.Build().Run();
