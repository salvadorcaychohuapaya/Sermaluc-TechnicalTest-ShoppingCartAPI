using ShoppingCart.Application;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Domain;
using ShoppingCart.Infrastructure;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "product.json");
var product = JsonSerializer.Deserialize<ProductDefinition>(
    await File.ReadAllTextAsync(jsonPath),
    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
) ?? throw new InvalidOperationException("No se pudo cargar el product.json");

builder.Services.AddSingleton(product);
builder.Services.AddSingleton<ICartRepository, CartRepository>();
builder.Services.AddScoped<CartService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
