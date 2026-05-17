using Microsoft.EntityFrameworkCore;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Models.Entities;
using SistemaInventario.Repositories.Database;


namespace SistemaInventario.Repositories.Repositories;
public class UsuarioRepositories : IUsuarioRepositories{
    private readonly AppDbContext _context;

    public UsuarioRepositories(AppDbContext context){
        _context = context;
    }

    public async Task<List<Usuario>> ObtenerTodos(){
        return await _context.Usuarios.ToListAsync();
    }
    public async Task<Usuario?> ObtenerPorId(int Id){
        return await _context.Usuarios.FindAsync(Id);
    }
    public async Task Crear(Usuario usuario){
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id,Usuario usuario){
        var usuarios = await _context.Usuarios.FindAsync(Id);
        if(usuarios == null){
            throw new Exception("No existe este usuario.");
        };

        usuarios.Nombre = usuario.Nombre;
        usuarios.Email = usuario.Email;
        usuarios.Password = usuario.Password;
        usuarios.Rol = usuario.Rol;
        await _context.SaveChangesAsync();
    }
    public async Task<Usuario?> ObtenerPorEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(c => c.Email == email);
    }
    public async Task Eliminar(int Id){
        var usuario = await _context.Usuarios.FindAsync(Id);
        if(usuario == null){
            throw new Exception("No existe este usuario.");
        };
        _context.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}
