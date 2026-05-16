using Microsoft.EntityFrameworkCore;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Models.Entities;
using SistemaInventario.Repositories.Database;

namespace SistemaInventario.Repositories.Repositories;

public class AlmacenRepositories : IAlmacenRepositories{
    private readonly AppDbContext _context;

    public AlmacenRepositories(AppDbContext context){
        _context = context;  
    }

    public async Task<List<Almacen>> ObtenerTodos(){
        return await _context.Almacenes.ToListAsync();
    }
    public async Task<Almacen?> ObtenerPorId(int Id){
        return await _context.Almacenes.FindAsync(Id);
    }
    public async Task Crear(Almacen almacen){
        await _context.Almacenes.AddAsync(almacen);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id,Almacen almacen){
        var almacenes = await _context.Almacenes.FindAsync(Id);
        if(almacenes == null){
            throw new Exception("No existe este almacen.");
        };
        almacenes.Nombre = almacen.Nombre;
        almacenes.Empresa = almacen.Empresa;
        almacenes.Direccion = almacen.Direccion;
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var almacen = await _context.Almacenes.FindAsync(Id);
        if(almacen == null){
            throw new Exception("No existe este almacen.");
        };
        _context.Remove(almacen);
        await _context.SaveChangesAsync();
    }
}