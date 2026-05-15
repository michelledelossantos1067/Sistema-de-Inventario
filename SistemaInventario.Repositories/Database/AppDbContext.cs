using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models.Entities;
using SistemaInventario.Models.Enums;

namespace SistemaInventario.Repositories.Database;

public class AppDbContext : DbContext{

public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
        .Property(p => p.PrecioVenta)
        .HasPrecision(18, 2);
        modelBuilder.Entity<Producto>()
        .Property(p => p.PrecioCompra)
        .HasPrecision(18, 2);
        modelBuilder.Entity<Factura>()
        .Property(p => p.Total)
        .HasPrecision(18, 2);
        modelBuilder.Entity<DetalleFactura>()
        .Property(p => p.PrecioUnitario)
        .HasPrecision(18, 2);
        modelBuilder.Entity<DetalleFactura>()
        .HasOne(d => d.Producto)
        .WithMany()
        .HasForeignKey(d => d.ProductoId)
        .OnDelete(DeleteBehavior.NoAction);
    }
    public DbSet<Producto> Productos {get;set;}
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Usuario> Usuarios {get;set;}
    public DbSet<Proveedor> Proveedores {get;set;}
    public DbSet<Factura> Facturas {get;set;}
    public DbSet<DetalleFactura> DetallesFacturas {get;set;}
    public DbSet<Movimiento> Movimientos {get;set;}
}