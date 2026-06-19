using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// ✅ Allow Codespaces dynamic origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCodespaces", policy =>
    {
        policy.SetIsOriginAllowed(origin => true)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ✅ Enable CORS BEFORE endpoints
app.UseCors("AllowCodespaces");

app.MapGet("/api/productlist", () =>
{
    return new[]
    {
        new
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50,
            Stock = 25,
            Category = new
            {
                Id = 101,
                Name = "Electronics"
            }
        },
        new
        {
            Id = 2,
            Name = "Headphones",
            Price = 50.00,
            Stock = 100,
            Category = new
            {
                Id = 102,
                Name = "Accessories"
            }
        }
    };
});

app.Run();