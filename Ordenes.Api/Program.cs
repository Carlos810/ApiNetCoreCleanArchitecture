using Ordenes.Application.Services;
using Ordenes.Application.Interfaces;
using Ordenes.Infrastructure.Repositories;
using System.Reflection;
using Ordenes.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// =======================
// Services
// =======================
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ClienteService>();


// Controllers (MVC API)
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Ordenes API",
        Version = "v1",
        Description = "API para gestión de Clientes, Productos y Pedidos"
    });
});

var app = builder.Build();

// =======================
// Middleware
// =======================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordenes API v1");
        options.RoutePrefix = string.Empty; // Swagger en /
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

try
{
    app.MapControllers();
}
catch (ReflectionTypeLoadException ex)
{
    foreach (var e in ex.LoaderExceptions)
    {
        Console.WriteLine("LOADER EXCEPTION:");
        Console.WriteLine(e?.Message);
        Console.WriteLine(e?.StackTrace);
        Console.WriteLine("---------------");
    }
    throw;
}

app.Run();
