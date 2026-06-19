using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// ✅ Copilot suggestion: Enforce camelCase JSON (industry standard)
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// ✅ Copilot suggestion: Enable flexible CORS for frontend integration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCodespaces", policy =>
    {
        policy.SetIsOriginAllowed(origin => true)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ✅ Copilot optimization: Add in-memory caching to reduce server load
builder.Services.AddMemoryCache();

var app = builder.Build();

// ✅ Must be before endpoints
app.UseCors("AllowCodespaces");

// ✅ Optimized API endpoint with caching
app.MapGet("/api/productlist", (IMemoryCache cache) =>
{
    const string cacheKey = "productList";

    // ✅ Avoid redundant processing (Copilot optimization)
    if (!cache.TryGetValue(cacheKey, out object? productList))
    {
        productList = new[]
        {
            new
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200.50,
                Stock = 25,
                Category = new { Id = 101, Name = "Electronics" }
            },
            new
            {
                Id = 2,
                Name = "Headphones",
                Price = 50.00,
                Stock = 100,
                Category = new { Id = 102, Name = "Accessories" }
            }
        };

        // ✅ Cache data for 5 minutes
        cache.Set(cacheKey, productList, TimeSpan.FromMinutes(5));

        Console.WriteLine("✅ Data generated and cached");
    }
    else
    {
        Console.WriteLine("✅ Data served from cache");
    }

    return productList;
});

app.Run();

/*
✅ PERFORMANCE OPTIMIZATION SUMMARY (Copilot-assisted)

1. Backend caching implemented using IMemoryCache
2. Reduced redundant API processing
3. Faster response times for repeated requests
4. Scalable and efficient API design
*/