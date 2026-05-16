using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.InventarioAlmacen;

namespace SistemaInventario.Application.Interfaces.Services;

public interface IInventarioAlmacenServices{
    public Task<List<InventarioAlmacenResponseDTOs>> ObtenerTodos();
    public Task<InventarioAlmacenResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateInventarioAlmacenDTOs createAlmacenDTOs);
    public Task Actualizar(int Id,UpdateInventarioAlmacenDTOs updateAlmacenDTOs);
    public Task Eliminar(int Id);
}