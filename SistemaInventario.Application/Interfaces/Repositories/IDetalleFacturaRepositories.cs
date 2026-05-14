using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IDetalleFacturaRepositories{
    public Task<List<DetalleFactura>> ObtenerTodos();
    public Task<DetalleFactura?> ObtenerPorId(int Id);
    public Task Crear(DetalleFactura detalleFactura);
    public Task Actualizar(int Id,DetalleFactura detalleFactura);
    public Task Eliminar(int Id);
    
}