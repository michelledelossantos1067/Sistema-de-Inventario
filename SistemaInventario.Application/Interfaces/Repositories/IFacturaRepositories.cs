using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IFacturaRepositories{
    public Task<List<Factura>> ObtenerTodos();
    public Task<Factura?> ObtenerPorId(int Id);
    public Task Crear(Factura factura);
    public Task Actualizar(int Id,Factura factura);
    public Task Eliminar(int Id);
    
}