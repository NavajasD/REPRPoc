using REPRPoc.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureFastEndpoints();
builder.Services.ConfigureSwagger();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseSwagger();

app.Run();


