using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.DetalleFactura;

namespace SistemaInventario.Application.Interfaces.Services;

public interface IDetalleFacturaServices{
    public Task<List<DetalleFacturaResponseDTOs>> ObtenerTodos();
    public Task<DetalleFacturaResponseDTOs?> ObtenerPorId(int Id);
    public Task Crear(CreateDetalleFacturaDTOs createDetalleFacturaDTOs);
    public Task Actualizar(int Id,UpdateDetalleFacturaDTOs updateDetalleFacturaDTOs);
    public Task Eliminar(int Id);
    
}