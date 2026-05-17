using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IInventarioAlmacenRepositories{
    public Task<List<InventarioAlmacen>> ObtenerTodos();
    public Task<InventarioAlmacen?> ObtenerPorId(int Id);
    public Task Crear(InventarioAlmacen InventarioAlmacen);
    public Task Actualizar(int Id, InventarioAlmacen InventarioAlmacen);
    public Task<InventarioAlmacen?> ObtenerPorProductoYAlmacen(int productoId, int almacenId);
    public Task Eliminar(int Id);
    
}