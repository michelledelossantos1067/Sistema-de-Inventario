using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Proveedor;
namespace SistemaInventario.Application.Interfaces.Services;

public interface IProveedorServices{
    public Task<List<ProveedorResponseDTOs>> ObtenerTodos();
    public Task<ProveedorResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateProveedorDTOs createProveedorDTOs);
    public Task Actualizar(int Id,UpdateProveedorDTOs updateProveedorDTOs);
    public Task Eliminar(int Id);
    
}