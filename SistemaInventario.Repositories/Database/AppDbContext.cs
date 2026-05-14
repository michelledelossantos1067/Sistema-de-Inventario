using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models.Entities;
using SistemaInventario.Models.Enums;

namespace SistemaInventario.Repositories.Database;

public class AppDbContext : DbContext{

public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Producto> Productos {get;set;}
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Usuario> Usuarios {get;set;}
    public DbSet<Proveedor> Proveedores {get;set;}
    public DbSet<Factura> Facturas {get;set;}
    public DbSet<DetalleFactura> DetallesFacturas {get;set;}
    public DbSet<Movimiento> Movimientos {get;set;}
}