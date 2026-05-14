using SistemaInventario.Models.Entities;
namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IProductoRepositories{
    public Task<List<Producto>> ObtenerTodos();
    public Task<Producto?> ObtenerPorId(int Id);
    public Task Crear(Producto producto);
    public Task Actualizar(int Id,Producto producto);
    public Task Eliminar(int Id);
}