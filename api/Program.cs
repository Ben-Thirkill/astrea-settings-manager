using api.Core.Builders;
using api.Core.Managers;
using api.Core.Models;
using api.Core.Settings.SettingTypes;
using api.Core.Stores;
using api.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Data Source=database.db"));

builder.Services.AddControllers();

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

app.UseCors();

app.MapControllers();

Setting _settingStr = new SettingBuilder("app_name", new StringSettingType())
    .SetDefaultValue("Super Todo App")
    .SetName("App Name")
    .SetDescription("What should the app be called?")
    .SetModule("general_settings")
    .Build();

Setting _settingBool = new SettingBuilder("dark_mode", new BooleanSettingType())
    .SetDefaultValue("false")
    .SetName("Dark Mode")
    .SetDescription("Should dark mode be on by default?")
    .SetModule("general_settings")
    .Build();

SettingManager _manager = new SettingManager(SettingStore.Instance);

_manager.AddSetting(_settingStr);
_manager.AddSetting(_settingBool);

app.Run();

