using SistemaInventario.Models.Entities;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Repositories.Repositories;

public class ProveedorRepositories : IProveedorRepositories{
    private readonly AppDbContext _context;

    public ProveedorRepositories(AppDbContext context){
        _context = context;
    }
    public async Task<List<Proveedor>> ObtenerTodos(){
        return await _context.Proveedores.ToListAsync();
    }
    public async Task<Proveedor?> ObtenerPorId(int Id){
        return await _context.Proveedores.FindAsync(Id);
    }
    public async Task Crear(Proveedor proveedor){
        await _context.Proveedores.AddAsync(proveedor);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id, Proveedor proveedor){
        var proveedores = await _context.Proveedores.FindAsync(Id);
        if(proveedores == null){
            throw new Exception("El proveedor no existe.");
        };
        proveedores.Nombre = proveedor.Nombre;
        proveedores.RNC = proveedor.RNC;
        proveedores.Telefono = proveedor.Telefono;
        proveedores.Direccion = proveedor.Direccion;
        proveedores.Email = proveedor.Email;
        
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var proveedor = await _context.Proveedores.FindAsync(Id);
        if (proveedor == null){
            throw new Exception("El proveedor no existe.");
        };
        _context.Remove(proveedor);
        await _context.SaveChangesAsync();
    }
    
}