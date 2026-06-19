var builder = WebApplication.CreateBuilder(args);

// ✅ Allow Codespaces dynamic origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCodespaces", policy =>
    {
        policy.SetIsOriginAllowed(origin => true) // ✅ allow all Codespaces URLs
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ✅ Enable CORS BEFORE endpoints
app.UseCors("AllowCodespaces");

app.MapGet("/api/products", () =>
{
    return new[]
    {
        new { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25 },
        new { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100 }
    };
});

app.Run();
