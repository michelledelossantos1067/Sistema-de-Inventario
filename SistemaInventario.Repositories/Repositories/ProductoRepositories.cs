using SistemaInventario.Models.Entities;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Repositories.Repositories;

public class ProductoRepositories : IProductoRepositories{
    private readonly AppDbContext _context;

    public ProductoRepositories(AppDbContext context){
        _context = context;
    }
    public async Task<List<Producto>> ObtenerTodos(){
        return await _context.Productos.ToListAsync();
    }
    public async Task<Producto?> ObtenerPorId(int Id){
        return await _context.Productos.FindAsync(Id);
    }
    public async Task Crear(Producto producto){
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id, Producto producto){
        var productos = await _context.Productos.FindAsync(Id);
        if(productos == null){
            throw new Exception("El producto no existe.");
        };

        productos.Codigo = producto.Codigo;
        productos.Nombre = producto.Nombre;
        productos.Descripcion = producto.Descripcion;
        productos.MedidaUnidad = producto.MedidaUnidad;
        productos.PrecioVenta = producto.PrecioVenta;
        productos.PrecioCompra = producto.PrecioCompra;
        productos.ImagenUrl = producto.ImagenUrl;
        productos.CategoriaId = producto.CategoriaId;
        productos.ProveedorId = producto.ProveedorId;
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var productos = await _context.Productos.FindAsync(Id);
        if (productos == null){
            throw new Exception("El producto no existe.");
        };
        _context.Remove(productos);
        await _context.SaveChangesAsync();
    }
    
}
