using SistemaInventario.Models.Entities;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Repositories.Repositories;
public class MovimientoRepositories : IMovimientoRepositories{
    private readonly AppDbContext _context;

    public MovimientoRepositories(AppDbContext context){
        _context = context;
    }
    public async Task<List<Movimiento>> ObtenerTodos(){
        return await _context.Movimientos.ToListAsync();
    }
    public async Task<Movimiento?> ObtenerPorId(int Id){
        return await _context.Movimientos.FindAsync(Id);
    }
    public async Task Crear(Movimiento movimiento){
        await _context.Movimientos.AddAsync(movimiento);
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var movimiento = await _context.Movimientos.FindAsync(Id);
        if (movimiento == null){
            throw new Exception("El movimiento no existe.");
        };
         
        _context.Remove(movimiento);
        await _context.SaveChangesAsync();
    }
    
}
