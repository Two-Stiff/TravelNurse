var builder = WebApplication.CreateBuilder(args);

var swaggerUrl = "https://localhost:61349";

if (builder.Environment.IsDevelopment())
{
    
}

var app = builder.Build();


app.Run();