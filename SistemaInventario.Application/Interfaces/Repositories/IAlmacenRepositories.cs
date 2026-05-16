using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IAlmacenRepositories{
    public Task<List<Almacen>> ObtenerTodos();
    public Task<Almacen?> ObtenerPorId(int Id);
    public Task Crear(Almacen almacen);
    public Task Actualizar(int Id,Almacen almacen);
    public Task Eliminar(int Id);
    
}