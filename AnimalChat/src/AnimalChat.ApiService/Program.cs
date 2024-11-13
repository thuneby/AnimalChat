using AnimalChat.ApiService.Apis;
using Microsoft.OpenApi.Models; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policybuilder =>
    {
        policybuilder.AllowAnyOrigin();
        policybuilder.AllowAnyHeader();
        policybuilder.AllowAnyMethod();
    });
});

//builder.Services.AddProblemDetails();


var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
//app.UseExceptionHandler();

app.MapGet("/images", async () =>
    await ImageApi.GetImagesAsync())
    .WithName("GetImages")
    .WithOpenApi();

app.MapGet("/images/{id}", async (int id) =>
        await ImageApi.GetImageAsync(id))
    .WithName("GetImage")
    .WithOpenApi();

app.Run();

