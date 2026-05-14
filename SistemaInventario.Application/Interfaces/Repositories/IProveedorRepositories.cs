using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IProveedorRepositories{
    public Task<List<Proveedor>> ObtenerTodos();
    public Task<Proveedor?> ObtenerPorId(int Id);
    public Task Crear(Proveedor proveedor);
    public Task Actualizar(int Id,Proveedor proveedor);
    public Task Eliminar(int Id);
    
}