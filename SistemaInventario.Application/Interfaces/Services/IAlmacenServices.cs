using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Almacen;

namespace SistemaInventario.Application.Interfaces.Services;

public interface IAlmacenServices{
    public Task<List<AlmacenResponseDTOs>> ObtenerTodos();
    public Task<AlmacenResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateAlmacenDTOs createAlmacenDTOs);
    public Task Actualizar(int Id,UpdateAlmacenDTOs updateAlmacenDTOs);
    public Task Eliminar(int Id);
}