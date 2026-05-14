using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.DetalleFactura;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Application.Interfaces.Repositories;
namespace SistemaInventario.Services.Services;

public class DetalleFacturaServices : IDetalleFacturaServices{
    private readonly IDetalleFacturaRepositories _detalleFacturaRepositories;

    public DetalleFacturaServices(IDetalleFacturaRepositories detalleFacturaRepositories){
        _detalleFacturaRepositories = detalleFacturaRepositories;
    }
    public async Task<List<DetalleFacturaResponseDTOs>> ObtenerTodos(){
        var factura = await _detalleFacturaRepositories.ObtenerTodos();
        return factura.Select(c => new DetalleFacturaResponseDTOs{
            Cantidad = c.Cantidad,
            PrecioUnitario = c.PrecioUnitario,
            FacturaId = c.FacturaId,
            ProductoId = c.ProductoId
        }).ToList();
    }
    public async Task<DetalleFacturaResponseDTOs?> ObtenerPorId(int Id){
        var detalleFactura = await _detalleFacturaRepositories.ObtenerPorId(Id);
        if (detalleFactura == null){
            return null;
        };
        var detalleFacturaDTOs = new DetalleFacturaResponseDTOs{
            Id = detalleFactura.Id,
            Cantidad = detalleFactura.Cantidad,
            PrecioUnitario = detalleFactura.PrecioUnitario,
            FacturaId = detalleFactura.FacturaId,
            ProductoId = detalleFactura.ProductoId
        };
        
        return detalleFacturaDTOs;
    }
    public async Task Crear(CreateDetalleFacturaDTOs createDetalleFacturaDTOs){
        var detalleFacturaDTOs = new DetalleFactura{
            Cantidad = createDetalleFacturaDTOs.Cantidad,
            PrecioUnitario = createDetalleFacturaDTOs.PrecioUnitario,
            FacturaId = createDetalleFacturaDTOs.FacturaId,
            ProductoId = createDetalleFacturaDTOs.ProductoId
        };
        await _detalleFacturaRepositories.Crear(detalleFacturaDTOs);
    }
    public async Task Actualizar(int Id, UpdateDetalleFacturaDTOs updateDetalleFacturaDTOs){
        var detalleFactura = await _detalleFacturaRepositories.ObtenerPorId(Id);
        if(detalleFactura == null){
            throw new Exception("El detalle de la factura no existe.");
        };
        detalleFactura.Cantidad = updateDetalleFacturaDTOs.Cantidad;
        detalleFactura.FacturaId = updateDetalleFacturaDTOs.FacturaId;
        detalleFactura.ProductoId = updateDetalleFacturaDTOs.ProductoId;
        
        await _detalleFacturaRepositories.Actualizar(Id,detalleFactura);
    }
    
    public async Task Eliminar(int Id){
        var detalleFactura = await _detalleFacturaRepositories.ObtenerPorId(Id);
        if (detalleFactura == null){
            throw new Exception("El detalle de factura no existe.");
        };
        await _detalleFacturaRepositories.Eliminar(Id);
    }
}