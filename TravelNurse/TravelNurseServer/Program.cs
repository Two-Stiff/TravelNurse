using Microsoft.EntityFrameworkCore;
using TravelNurseServer.Data;

var builder = WebApplication.CreateBuilder(args);

var swaggerUrl = "https://localhost:61349";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers(); // Needed for API endpoints
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();



app.Run();