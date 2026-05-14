using SistemaInventario.Models.Entities;
using SistemaInventario.Models.DTOs.Factura;
using SistemaInventario.Application.Interfaces.Services;
using SistemaInventario.Application.Interfaces.Repositories;

namespace SistemaInventario.Services.Services;
public class FacturaServices : IFacturaServices{
    private readonly IFacturaRepositories _facturaRepositories;

    public FacturaServices(IFacturaRepositories facturaRepositories){
        _facturaRepositories = facturaRepositories;
    }
    public async Task<List<FacturaResponseDTOs>> ObtenerTodos(){
        var factura = await _facturaRepositories.ObtenerTodos();
        return factura.Select(c => new FacturaResponseDTOs{
            Total = c.Total,
            UsuarioId = c.UsuarioId,
            ProveedorId = c.ProveedorId
        }).ToList();
    }
    public async Task<FacturaResponseDTOs?> ObtenerPorId(int Id){
        var factura = await _facturaRepositories.ObtenerPorId(Id);
        if (factura == null){
            return null;
        };
        var facturaDTOs = new FacturaResponseDTOs{
            Id = factura.Id,
            Total = factura.Total,
            UsuarioId = factura.UsuarioId,
            ProveedorId = factura.ProveedorId
        };
        
        return facturaDTOs;
    }
    public async Task Crear(CreateFacturaDTOs createFacturaDTOs){
        var facturaDTOs = new Factura{
            FechaFactura = createFacturaDTOs.FechaFactura,
            FechaLimite = createFacturaDTOs.FechaLimite,
            Estado = createFacturaDTOs.Estado,
            UsuarioId = createFacturaDTOs.UsuarioId,
            ProveedorId = createFacturaDTOs.ProveedorId
        };
        await _facturaRepositories.Crear(facturaDTOs);
    }
    public async Task Actualizar(int Id, UpdateFacturaDTOs updateFacturaDTOs){
        var factura = await _facturaRepositories.ObtenerPorId(Id);
        if(factura == null){
            throw new Exception("La factura no existe.");
        };
        factura.FechaLimite = updateFacturaDTOs.FechaLimite;
        factura.Estado = updateFacturaDTOs.Estado;
        factura.UsuarioId = updateFacturaDTOs.UsuarioId;
        factura.ProveedorId = updateFacturaDTOs.ProveedorId;
        
        await _facturaRepositories.Actualizar(Id,factura);
    }
    
    public async Task Eliminar(int Id){
        var factura = await _facturaRepositories.ObtenerPorId(Id);
        if (factura == null){
            throw new Exception("La factura no existe.");
        };
        await _facturaRepositories.Eliminar(Id);
    }
}
