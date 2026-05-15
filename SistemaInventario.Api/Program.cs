using Microsoft.EntityFrameworkCore;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Repositories.Database;
using SistemaInventario.Repositories.Repositories;
using SistemaInventario.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddScoped<ICategoriaRepositories, CategoriaRepositories>();
builder.Services.AddScoped<IDetalleFacturaRepositories, DetalleFacturaRepositories>();
builder.Services.AddScoped<IFacturaRepositories, FacturaRepositories>();
builder.Services.AddScoped<IMovimientoRepositories, MovimientoRepositories>();
builder.Services.AddScoped<IProductoRepositories, ProductoRepositories>();
builder.Services.AddScoped<IProveedorRepositories, ProveedorRepositories>();
builder.Services.AddScoped<IUsuarioRepositories, UsuarioRepositories>();

builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddScoped<IDetalleFacturaServices, DetalleFacturaServices>();
builder.Services.AddScoped<IFacturaServices, FacturaServices>();
builder.Services.AddScoped<IMovimientoServices, MovimientoServices>();
builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IProveedorServices, ProveedorServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();

var app = builder.Build();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();