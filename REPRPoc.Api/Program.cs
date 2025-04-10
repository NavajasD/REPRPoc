using REPRPoc.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSecurity(builder.Configuration);
builder.Services.ConfigureFastEndpoints();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureServices();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseSecurity();
app.UseFastEndpoints();
app.UseSwagger();

app.Run();


