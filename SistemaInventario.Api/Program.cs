using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaInventario.Api.Middleware;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Repositories.Database;
using SistemaInventario.Repositories.Repositories;
using SistemaInventario.Services.Services;
;
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
builder.Services.AddScoped<IAlmacenRepositories, AlmacenRepositories>();
builder.Services.AddScoped<IInventarioAlmacenRepositories, InventarioAlmacenRepositories>();

builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddScoped<IDetalleFacturaServices, DetalleFacturaServices>();
builder.Services.AddScoped<IFacturaServices, FacturaServices>();
builder.Services.AddScoped<IMovimientoServices, MovimientoServices>();
builder.Services.AddScoped<IProductoServices, ProductoServices>();
builder.Services.AddScoped<IProveedorServices, ProveedorServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<IAlmacenServices, AlmacenServices>();
builder.Services.AddScoped<IInventarioAlmacenServices, InventarioAlmacenServices>();
builder.Services.AddScoped<IAuthServices, AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();