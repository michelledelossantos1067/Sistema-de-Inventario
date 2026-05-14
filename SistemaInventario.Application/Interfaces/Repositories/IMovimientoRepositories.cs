using SistemaInventario.Models.Entities;

namespace SistemaInventario.Application.Interfaces.Repositories;

public interface IMovimientoRepositories{
    public Task<List<Movimiento>> ObtenerTodos();
    public Task<Movimiento?> ObtenerPorId(int Id);
    public Task Crear(Movimiento movimiento);
    public Task Eliminar(int Id);
    
}