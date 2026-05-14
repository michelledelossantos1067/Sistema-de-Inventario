using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IUsuarioRepositories{
    public Task<List<Usuario>> ObtenerTodos();
    public Task<Usuario?> ObtenerPorId(int Id);
    public Task Crear(Usuario usuario);
    public Task Actualizar(int Id,Usuario usuario);
    public Task Eliminar(int Id);
    
}