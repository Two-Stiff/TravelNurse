using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using TravelNurse.Components;
using TravelNurse.Components.Common.Services;
using TravelNurse.Components.Common.Utils;
using TravelNurse.Components.Src.ContextStore;
using TravelNurseServer.Common;
using TravelNurseServer.Data;
using TravelNurseServer.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Adding MudBlazor to the project
builder.Services.AddMudServices();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<DataContext>(options =>
    options.UseNpgsql(connectionString)
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//
//
builder.Services.AddAutoMapper(typeof(ServerAutoMapperProfile));
builder.Services.ConfigureServices();

// Context store
builder.Services.ConfigureContextStoreServices();
builder.Services.ConfigureTravelNurseServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();