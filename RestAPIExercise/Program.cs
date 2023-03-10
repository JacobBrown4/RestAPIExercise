using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using RestAPIExercise.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RestAPIContext>(opt =>
opt.UseInMemoryDatabase("RestAPI"));
builder.Services.AddScoped<SeedData>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(api =>
{
    api.AssumeDefaultVersionWhenUnspecified = false;
    api.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    api.ReportApiVersions = true;
    api.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});

var _logger = new LoggerConfiguration().WriteTo.File("C:\\RestAPI\\Logs\\ApiLogs-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.AddSerilog(_logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.SeedSQLServer();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
