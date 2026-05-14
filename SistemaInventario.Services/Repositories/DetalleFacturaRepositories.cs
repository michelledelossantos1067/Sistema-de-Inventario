using SistemaInventario.Models.Entities;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Repositories.Repositories;
public class DetalleFacturaRepositories : IDetalleFacturaRepositories{
    private readonly AppDbContext _context;

    public DetalleFacturaRepositories(AppDbContext context){
        _context = context;
    }
    public async Task<List<DetalleFactura>> ObtenerTodos(){
        return await _context.DetallesFacturas.ToListAsync();
    }
    public async Task<DetalleFactura?> ObtenerPorId(int Id){
        return await _context.DetallesFacturas.FindAsync(Id);
    }
    public async Task Crear(DetalleFactura detalleFactura){
        await _context.DetallesFacturas.AddAsync(detalleFactura);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id, DetalleFactura detalleFactura){
        var detalle = await _context.DetallesFacturas.FindAsync(Id);
        if(detalle == null){
            throw new Exception("El detalle de factura no existe.");
        };
        detalle.Cantidad = detalleFactura.Cantidad;
        detalle.PrecioUnitario = detalleFactura.PrecioUnitario;
        detalle.ProductoId = detalleFactura.ProductoId;
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var detalle = await _context.DetallesFacturas.FindAsync(Id);
        if (detalle == null){
            throw new Exception("El detalle de factura no existe.");
        };
        _context.Remove(detalle);
        await _context.SaveChangesAsync();
    }
}