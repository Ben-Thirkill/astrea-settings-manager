using api.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Data Source=database.db"));

// Add Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Settings API V1");
    c.RoutePrefix = string.Empty; // Serve Swagger at the root /
});

// Optional: enforce HTTPS
app.UseHttpsRedirection();

// Example minimal API endpoint
app.MapGet("/health", () => Results.Ok(new { Status = "Running" }))
    .WithName("HealthCheck");

app.Run();