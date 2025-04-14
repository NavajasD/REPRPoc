using REPRPoc.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSecurity(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.ConfigureServices();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureCache();

builder.Services.ConfigureFastEndpoints();

builder.Host.ConfigureLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseSecurity();
app.UseSwagger();
app.UseCache();

app.UseFastEndpoints();
app.Run();


