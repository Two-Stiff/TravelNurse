using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Common;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos;

var builder = WebApplication.CreateBuilder(args);

var swaggerUrl = "https://localhost:61349";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<DataContext>(options =>
    options.UseNpgsql(connectionString)
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddControllers(); // Needed for API endpoints
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
builder.Services.AddSwaggerGen();




builder.Services.ConfigureServices();

builder.Services.AddAutoMapper(typeof(ServerAutoMapperProfile));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();



app.Run();