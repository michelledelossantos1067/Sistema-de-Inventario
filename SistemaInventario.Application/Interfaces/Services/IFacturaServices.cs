using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Factura;
namespace SistemaInventario.Application.Interfaces.Services;

public interface IFacturaServices{
    public Task<List<FacturaResponseDTOs>> ObtenerTodos();
    public Task<FacturaResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateFacturaDTOs createFacturaDTOs);
    public Task Actualizar(int Id,UpdateFacturaDTOs updateFacturaDTOs);
    public Task Eliminar(int Id);
    
}