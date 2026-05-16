using Microsoft.EntityFrameworkCore;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Models.Entities;
using SistemaInventario.Repositories.Database;

namespace SistemaInventario.Repositories.Repositories;

public class InventarioAlmacenRepositories : IInventarioAlmacenRepositories{
    private readonly AppDbContext _context;

    public InventarioAlmacenRepositories(AppDbContext context){
        _context = context;  
    }

    public async Task<List<InventarioAlmacen>> ObtenerTodos(){
        return await _context.InventarioAlmacenes.ToListAsync();
    }
    public async Task<InventarioAlmacen?> ObtenerPorId(int Id){
        return await _context.InventarioAlmacenes.FindAsync(Id);
    }
    public async Task Crear(InventarioAlmacen inventarioAlmacen){
        await _context.InventarioAlmacenes.AddAsync(inventarioAlmacen);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id,InventarioAlmacen inventarioAlmacen){
        var inventarioAlmacenes = await _context.InventarioAlmacenes.FindAsync(Id);
        if(inventarioAlmacenes == null){
            throw new Exception("No existe este almacen.");
        };
        inventarioAlmacenes.ProductoId = inventarioAlmacen.ProductoId;
        inventarioAlmacenes.AlmacenId = inventarioAlmacen.AlmacenId;
        inventarioAlmacenes.Stock = inventarioAlmacen.Stock;
        inventarioAlmacenes.StockMinimo = inventarioAlmacen.StockMinimo;
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var inventarioAlmacen = await _context.InventarioAlmacenes.FindAsync(Id);
        if(inventarioAlmacen == null){
            throw new Exception("No existe este almacen.");
        };
        _context.Remove(inventarioAlmacen);
        await _context.SaveChangesAsync();
    }
}