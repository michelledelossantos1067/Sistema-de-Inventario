using SistemaInventario.Models.Entities;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Repositories.Repositories;

public class CategoriaRepositories : ICategoriaRepositories{
    private readonly AppDbContext _context;

    public CategoriaRepositories(AppDbContext context){
        _context = context;
    }

    public async Task<List<Categoria>> ObtenerTodos(){
        return await _context.Categorias.ToListAsync();
    }
    public async Task<Categoria?> ObtenerPorId(int Id){
        return await _context.Categorias.FindAsync(Id);
    }
    public async Task Crear(Categoria categoria){
        await _context.Categorias.AddAsync(categoria);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id,Categoria categoria){
        var categorias = await _context.Categorias.FindAsync(Id);
        if(categorias == null){
            throw new Exception("No existe esta categoria.");
        };
        categorias.Nombre = categoria.Nombre;
        categorias.Descripcion = categoria.Descripcion;
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var categoria = await _context.Categorias.FindAsync(Id);
        if(categoria == null){
            throw new Exception("No existe esta categoria.");
        };
        _context.Remove(categoria);
        await _context.SaveChangesAsync();
    }
}