using SistemaInventario.Models.Entities;
using SistemaInventario.Application.Interfaces.Repositories;
using SistemaInventario.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Repositories.Repositories;
public class FacturaRepositories : IFacturaRepositories{
    private readonly AppDbContext _context;

    public FacturaRepositories(AppDbContext context){
        _context = context;
    }
    public async Task<List<Factura>> ObtenerTodos(){
        return await _context.Facturas.ToListAsync();
    }
    public async Task<Factura?> ObtenerPorId(int Id){
        return await _context.Facturas.FindAsync(Id);
    }
    public async Task Crear(Factura factura){
        await _context.Facturas.AddAsync(factura);
        await _context.SaveChangesAsync();
    }
    public async Task Actualizar(int Id, Factura factura){
        var facturas = await _context.Facturas.FindAsync(Id);
        if(facturas == null){
            throw new Exception("El factura no existe.");
        };
        facturas.Total = factura.Total;
        facturas.FechaFactura = factura.FechaFactura;
        facturas.FechaLimite = factura.FechaLimite;
        facturas.Estado = factura.Estado;
        facturas.UsuarioId = factura.UsuarioId;
        facturas.ProveedorId = factura.ProveedorId;
        await _context.SaveChangesAsync();
    }
    public async Task Eliminar(int Id){
        var factura = await _context.Facturas.FindAsync(Id);
        if (factura == null){
            throw new Exception("El factura no existe.");
        };
        _context.Remove(factura);
        await _context.SaveChangesAsync();
    }
}
