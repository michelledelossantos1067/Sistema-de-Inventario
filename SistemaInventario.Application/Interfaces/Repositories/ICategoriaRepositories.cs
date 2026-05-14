using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface ICategoriaRepositories{
    public Task<List<Categoria>> ObtenerTodos();
    public Task<Categoria?> ObtenerPorId(int Id);
    public Task Crear(Categoria categoria);
    public Task Actualizar(int Id,Categoria categoria);
    public Task Eliminar(int Id);
    
}